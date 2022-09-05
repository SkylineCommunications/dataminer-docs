---
uid: General_Feature_Release_10.0.6
---

# General Feature Release 10.0.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Security: LDAP queries will now time out after 5 minutes \[ID_25214\]

From now on, LDAP queries will, by default, time out after 5 minutes.

This setting can be configured in the *DataMiner.xml* file. Enter a value in seconds. If the LDAP.QueryTimeout tag is not present, a default value of 300 seconds (i.e. 5 minutes) will be taken. See the example below.

```xml
<DataMiner>
  <LDAP>
    <QueryTimeout>300</QueryTimeout>
  </LDAP>
</DataMiner>
```

> [!NOTE]
> This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than 5 minutes.

#### All DataMiner server DLLs now target Microsoft .NET Framework 4.6.2 \[ID_25269\]

All DataMiner server DLLs now target Microsoft .NET Framework 4.6.2.

### DMS Cube

#### Data Display: Table column layout can now be customized and saved per table \[ID_22866\]

It is now possible to save the layout of a table column after having customized it.

After changing the width, the position and/or the visibility of a column, right-click its header, and select *Save layout*. To reset the column layout to the default settings, select *Reset layout*.

#### Alarm hyperlinks: \[DisplayValue\] keywords now allows to display the value of a discreet parameter \[ID_25294\]

In second-generation alarm hyperlinks, you can now use the \[DISPLAYVALUE\] keyword to display the value of a discreet parameter.

#### Client machines running Cube now require Microsoft .NET Framework v4.6.2 \[ID_25309\]

Client machines running DataMiner Cube now require Microsoft .NET Framework 4.6.2.

#### Profiles app: Support for capability parameters of type 'text' \[ID_25345\]

The *Profiles* app now also allows you to create and edit profile parameters of category "Capability" and type "Text".

#### Creating an element simulation file \[ID_25353\]

On a DataMiner System, you can create simulated elements. These elements behave as if they are communicating with a physical device, but in fact they are merely displaying data from a simulation file.

From now on, in Cube, you can not only enable a simulation file, but also create one. To do so, in the navigation pane on the left, right-click the element for which you want to create a simulation file, and select *Actions \> Create simulation*.

When you open an element card, you can also access this same command via the card’s hamburger menu.

The simulation file will be stored on the DataMiner Agent, in the protocol folder of the element in question: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\Simulation_ELEMENTNAME.xml*

#### Resources app: Time-dependent capabilities \[ID_25409\]

When, in the *Resources* app, you assign a capability parameter to a resource, instead of specifying a fixed value for that parameter, you can now indicate that its value will be time-dependent, i.e. that the capability of the resource can change over time.

#### Visual Overview: SetVar controls 'ListBox' and 'FilterComboBox' now use virtualization \[ID_25436\]

The SetVar controls "ListBox" and "FilterComboBox" now both use virtualization. This will allow those controls to load large data sets without major performance loss.

#### Visual Overview: Retrieving a booking ID using the \[Reservation:\] placeholder \[ID_25447\]

Using the following syntax, it is now possible to retrieve the ID of a booking by means of a \[Reservation:\] placeholder.

```txt
[reservation:<bookingID/service>,ID]
```

### DMS Reports & Dashboards

#### Dashboards app: CPE feed will only pass along the deepest selected field \[ID_25304\]

From now on, a CPE feed will no longer pass along all selected fields. Instead, it will only pass along the deepest selected field.

### DMS Automation

#### Injecting a DLL into an Automation script \[ID_24945\]

It is now possible to inject DLL files into an Automation script.

##### To inject a DLL

1. Create an *AutomationDllInjectionItem* object that contains the following data:

    | Item     | Description                                                                                              |
    |------------|----------------------------------------------------------------------------------------------------------|
    | ScriptName | The name of the script into which the DLL will be injected.                                              |
    | ExeId      | The ID of the script action that will be replaced. Note: This script action must be a C# code block. |
    | Path       | The path to the DLL that will be injected. Note: This file must have the extension “.dll”.           |

1. Send the object to the server using an *InjectAutomationDllRequestMessage*.

The server will send back an *InjectAutomationDllResponseMessage*. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value           | Description                                                                                                                                       |
|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown         | An unknown error occurred.                                                                                                                        |
| NotAllowed      | The user who sent the message does not have the correct permissions.                                                                              |
| DllPathInvalid  | The DLL path is invalid. The file does not exist or does not have the extension “.dll”.                                                           |
| NotLicensed     | The DataMiner Agent is not licensed to use the Automation module.                                                                                 |
| InjectionFailed | The injection operation failed in SLAutomation. For more information, check the *SLAutomationErrors* property. |

To determine whether the injection was successful, you can check TraceData.HasSucceeded.

##### To request an overview of the injected DLLs

Send a *GetAutomationDllOverviewRequestMessage* to the server. This message does not have any properties.

The server will send back a *GetAutomationDllOverviewResponseMessage* containing a list of *AutomationDllInjectionItem* objects.

##### To eject a DLL

If you eject a previously injected DLL from an Automation script, this will cause the script to behave as it did before the injection. To do so, send an *EjectAutomationDllRequestMessage* containing the name of the script and the Exe ID (i.e. the ID of the script action).

The server will send back a EjectAutomationDllResponseMessage. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value | Description |
|--|--|
| Unknown | An unknown error occurred. |
| NotAllowed | The user who sent the message does not have the correct permissions. |
| NotLicensed | The DataMiner Agent is not licensed to use the Automation module. |
| EjectionFailed | The ejection operation failed in SLAutomation. For more information, check the *SLAutomationErrors* property. Note: This error will never be returned after injecting a DLL. See “To eject a DLL” below. |

##### To execute a script

Send an ExecuteScriptMessage to the server.

> [!NOTE]
>
> - Users who send the above-mentioned messages must have the “Automation \> Edit” permission to be able to inject or eject DLLs.
> - DLLs can be injected in scripts that have not yet been run.
> - When you restart the DataMiner Agent, the injected DLL will no longer be applied.

### DMS Mobile apps

#### Monitoring app: Alarm history now also available \[ID_25002\]

In the Monitoring app, alarm history is now also available.

#### Web applications updated to Microsoft .NET Framework 4.6.2 \[ID_25422\]

Web applications (Web Services API, legacy dashboards, Maps, etc.) have been updated to Microsoft .NET Framework 4.6.2.

### DMS Service & Resource Management

#### Exporting and importing profile parameters \[ID_24641\]

It is now possible to export and import profile parameters to and from a file.

The following methods have been added to the ProfileManagerHelper:

- `export(IEnumerable<Guid> ids)`

  This method returns an object of type “ProfileParameterExportResult”, which contains the bytes of the export file. These bytes can then be saved to a file. To view the contents of that file, first unzip it.

  When you export profile parameters to a file, the following exceptions can be thrown:

  | Exception | Description |
  |--|--|
  | ProfileParameterNotFoundException | The ID of one of the profile parameters that was passed to the method could not be found. |
  | MediationSnippetNotFoundException | One of the profile parameters that was passed to the method has a link to a mediation snippet that could not be found. |

- `import(byte[] file)`

  This method returns an object of type “ProfileParameterImportResult”, which contains the imported profile parameters and mediation snippets.

  When you import profile parameters from a file, the following exceptions can be thrown:

  | Exception                        | Description                                                                    |
  |----------------------------------|--------------------------------------------------------------------------------|
  | InvalidDataException             | The file to be imported does not have the correct format.                      |
  | InvalidProfileParameterException | One of the profile parameters to be imported does not have the correct format. |
  | InvalidMediationSnippetException | One of the mediation snippets to be imported does not have the correct format. |

> [!NOTE]
>
> - If you export a profile parameter, all the mediation snippets linked to that parameter will also be exported.
> - When you import profile parameters and their mediation snippets, all existing profile parameters and mediation snippets with the same ID will be overwritten.

#### Tracking the history of ReservationInstances \[ID_25006\]

All changes made to ReservationInstances will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-reservationinstance”).

A HistoryChange records contains the following fields:

| Field | Description |
|--|--|
| ID | ID of the HistoryChange record. |
| SubjectId | ID of the ReservationInstance that was changed. |
| Time | Time at which the change was made. |
| FullUsername | Full user name of the person who made the change. If the change was triggered by the DataMiner System, this will be “DataMiner”. |
| DmaId | ID of the DataMiner Agent on which the change was triggered. |
| Changes | List of changes that were made. In case of a ReservationInstance, this can be a resource usage change or a status change. |

> [!NOTE]
>
> - If, for some reason, tracking changes to ReservationInstances would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-reservationinstance table.
> - When a ReservationInstance is deleted, all HistoryChange records associated with this ReservationInstance will also be deleted, and a new HistoryChange record will be added to indicate when the ReservationInstance was deleted and by whom.

#### Linking an ID of a contributing resource to a ServiceReservationInstance \[ID_25186\]

It is now possible to link an ID of a contributing resource to a ServiceReservationInstance.

## Changes

### Enhancements

#### Enhanced notification of DataMiner processes when a DMA leaves the DataMiner System \[ID_24906\]

Due to a number of enhancements, DataMiner processes will now get notified in a more uniform way when a DataMiner Agent leaves the DataMiner System. This will allow them to execute the necessary tasks when such an event occurs.

#### DataMiner Cube - Visual Overview: 'Textblock' control now inherits text alignment of shape \[ID_24929\]

When you turned a shape into a text block control by adding a shape data item of type *Options* set to “Control=Textblock”, up to now, the text alignment of that control would by default be set to Left Center. From now on, “Textblock” controls will inherit the text alignment configuration of the shape.

#### Service & Resource Management: Enhanced performance when retrieving available resources \[ID_25061\]

Due to a number of enhancements, overall performance has increased when retrieving available resources (e.g. by means of the GetAvailableResource method).

#### Migrating booking data to Indexing Engine: Enhanced message in case of successful migration \[ID_25101\]

When a booking data migration to Indexing Engine completed successfully, up to now, the following message would appear:

```txt
The migration is done with 0 failed merge(s), but without exceptions or errors.
```

From now on, in case there are failed merges, the following message will appear instead:

```txt
The migration has been completed with X failed merge(s). There were no exceptions or errors.
```

#### DataMiner Cube - Trending: Enhanced accuracy of prediction data for history set parameters \[ID_25143\]

Due to a number of enhancements, the accuracy of prediction data for history set parameters has increased.

#### Decreased CPU load when installing DataMiner \[ID_25291\]

Due to a number of enhancements, overall CPU load has decreased when installing DataMiner.

#### Jobs app: Enhanced performance when viewing or editing a job \[ID_25292\]

Due to a number of enhancements, overall performance has increased when viewing or editing a job.

Also, a number of minor issues have been solved.

#### DataMiner Cube: Improved vertical alignment of hint text in password box of login screen \[ID_25303\]

In Cube’s login screen, the vertical alignment of the hint text in the password box has been improved.

#### DataMiner Cube - Alarm Console: Reduced memory consumption \[ID_25340\]

Due to a number of enhancements, the overall memory consumption of the Alarm Console has been reduced.

#### Backup: Backup.log file added to backup package \[ID_25347\]

When a backup package is created, from now on, the log information regarding the creation of that package will now be stored in the Backup.log file, which will be included in the package.

#### Default alarm bubble-up behavior in recursive tables changed from 'recursive=none' to 'recursive=up' \[ID_25349\]

The default alarm bubble-up behavior in recursive tables has been changed from “recursive=none” to “recursive=up”, i.e. from child nodes up to parent nodes (following the foreign key in the direction it is in).

#### DataMiner Cube - Data display: Partial tables with protocol-defined sorting now have a refresh button \[ID_25354\]

Partial tables with protocol-defined sorting now have a refresh button.

#### DataMiner Cube: Improved styling of action buttons in dynamic lists \[ID_25366\]

In dynamic lists, the action buttons have been restyled.

#### Monitoring app: Minor UI enhancements \[ID_25389\]

A number of minor UI enhancements have been made to the Monitoring app, especially in the View histogram page, the CPE topology page, the Spectrum page and the Data page.

#### DataMiner Cube - Header bar search box: Hidden and enhancing elements will no longer be included in the search results \[ID_25403\]

From now on, when you perform a search using the header box search box, the result set will no longer include hidden elements or view-enhancing elements.

#### Enhanced performance when writing data to Indexing Engine \[ID_25411\]

Due to a number of enhancements, overall performance has increased when writing data to the Indexing Engine.

#### Service & Resource Management: When checking whether a boolean ReservationInstance property is true or false, it is now also possible to specify the type as 'Bool' \[ID_25415\]

When checking whether a boolean ReservationInstance property is set to true or false, you can now specify the type as “Bool” as well as “Boolean”. See the following example:

```csharp
"ReservationInstance.Properties.\"Contributing Service\"[Bool]==false"
```

> [!NOTE]
>
> - Do not enclose the values true and false in single quotes. This would cause those values to be interpreted as string values instead of boolean values.
> - Do not enclose the filter in round brackets (...).

#### Dashboards app - Line chart component: Timestamp will now always remain visible in the legend \[ID_25421\]

When hovering over trend graph values in a line chart component, the associated timestamp will now always remain visible in the legend.

When the legend is collapsed, instead of not showing any timestamp, it will now show the timestamp above the trend values. When the legend is expanded, it will show the timestamp as it did before.

#### DataMiner Cube: User name box on login screen can now display user names with a length of up to 64 characters \[ID_25426\]

On the login screen, the user name box can now display user names with a length of up to 64 characters. Longer names will be displayed with a trailing ellipsis character (“...”).

#### Dashboards app: Pivot table supports mediation protocols \[ID_25491\]

The *Pivot table* dashboard component now supports mediation protocols.

### Fixes

#### DataMiner Cube - System Center: Agent name would not get updated after a Failover switch \[ID_24468\]

In the *Agents* section of *System Center*, after a Failover switch, in some cases, the agent name would not get updated to the name of the online agent.

#### DataMiner Cube - Scheduler: No 'next runtime', 'last runtime' or 'last runtime result' information displayed when a DMA in the DMS was unreachable \[ID_24894\]

On the List tab of the Scheduler app, in some cases, no “next runtime”, “last runtime” or “last runtime result” information would be displayed when one of the DataMiner Agent in the DMS was unreachable or disconnected.

#### SLDataMiner: Memory leak when retrieving security group information from the user directory \[ID_25080\]

In some cases, SLDataMiner could leak memory when retrieving security group information from the user directory.

#### Business Intelligence: Incorrect total violation time due to a rounding issue \[ID_25115\]

In some cases, the Total Violation Time could be incorrect due to a rounding issue.

#### Problem with implicitly launched downgrade actions during other than full upgrades \[ID_25158\]

Up to now, other than full upgrades that restarted DataMiner would implicitly have downgrade actions executed as part of the “Start” step. When the upgrade package contained a buildinfo.bin file with an old version number, in some cases, that could leave the system in a corrupted state.

#### Primary key(s) would be parsed incorrectly when reading from a logger table \[ID_25167\]

When reading from a logger table, in some cases, the primary key(s) would be parsed incorrectly.

#### SLNetClientTest tool: Messages/events displayed incorrectly in follow session \[ID_25184\]

In some cases, in a follow session of the SLNetClientTest tool, it could occur that some messages or events were displayed as "*Skyline.DataMiner.Net.Serialization.ProtoBufSerializedMessage*", making it impossible to check their content.

#### DataMiner Cube - EPM: EPM filter not loaded when topology cell was not linked to topology cell of selected object \[ID_25191\]

If an EPM (formerly known as CPE) element displayed a diagram, it could occur that a filter above a filter containing a selection remained empty if the former had a topology cell that was not linked to the topology cell of the selected object.

#### DataMiner Cube - EPM: Duplicate parameters in EPM details \[ID_25199\]

In some cases, when DataMiner Cube polled a direct view table for updates, it could occur that EPM (formerly known as CPE) parameters in the corresponding EPM details overview were duplicated.

#### DataMiner Cube - System Center: Not possible to delete unused Visio files \[ID_25209\]

In some cases, it would no longer be possible to delete unused Visio files in the Tools section of System Center.

#### ActiveDirectory.txt log file missing \[ID_25218\]

In some cases, it could occur that the *ActiveDirectory.txt* log file was not generated.

#### Problem with SLNet when performing a diagnostic request in the SLNetClientTest tool while view states were being recalculated \[ID_25219\]

In some cases, an error could occur in SLNet when you performed a diagnostic request (*Diagnostics \> Connections \> OpenConnections*) in the SLNetClientTest tool while view states were being recalculated.

#### Memory leak in SLNet when multiple documents were being added or deleted in rapid succession \[ID_25234\]

When multiple documents were being added or deleted in rapid succession, in some rare cases, SLNet could start leaking memory.

#### Mobile Gateway: Possible error when updating the cache due to a locking issue \[ID_25238\]

When SLGSMGateway updated its cache after an element had been added, updated or deleted, in some cases, an error could occur due to a locking issue.

#### Problem when the view column of a table containing DVE child elements to be created contained single view IDs \[ID_25255\]

A table containing DVE child elements to be created can have a column that contains the view(s) the child element has to be created in (i.e. a column with option=”view”). In the cells of this column, you can enter a single view ID, a single view name, a list of view IDs separated by semicolons, a list of view names separated by semicolons or a mixed list of view IDs and view names separated by semicolons.

In some cases, a problem could occur when single view IDs had been entered in this column.

#### SLNet: Problem when restarting a DataMiner Agent \[ID_25263\]

In some rare cases, the following exception could be thrown when restarting a DataMiner Agent:

```txt
Exception during startup of SLNet: System.IO.IOException: The process cannot access the file 'c:\skyline dataminer\logging\SLClient.txt' because it is being used by another process.
```

#### DataMiner Maps: Clusters would not get refreshed when panning on a map that only contained layers of which the LimitToBounds attribute was set to False \[ID_25265\]

When panning on a map that only contained layers of which the *limitToBounds* attribute was set to False, in some cases, the clusters would not get refreshed.

#### Dashboards app - Service Definition component: Elements disappeared from service definition nodes when web sockets were disabled \[ID_25275\]

When a Service Definition component was added to a dashboard, in some cases, elements would incorrectly disappear from service definition nodes when web sockets were disabled.

#### Problem with SLNet when retrieving CPU usage or memory usage \[ID_25279\]

In some cases, an error could occur in SLNet when retrieving the CPU usage or the memory usage.

#### Automation: Scripts using a library could no longer be executed after a DataMiner restart \[ID_25282\]

After a DataMiner restart, in some cases, Automation scripts that used a library could no longer be executed because the DataMiner Agent was not able to find the DLL file of that library.

#### DataMiner Cube - Workspaces: A saved workspace could no longer be opened in an undocked window \[ID_25308\]

In some cases, it would no longer be possible to open a saved workspace in an undocked window.

#### DataMiner Cube - Data Display: When a multiple parameter update was canceled, the parameter values would stay marked as modified \[ID_25313\]

When you updated multiple parameter values in one go and then canceled the update, in some cases, the parameter values in question would stay marked as modified.

Also, after updating other values, the multiple update window would incorrectly keep displaying the values for which the update had been canceled.

#### DataMiner Cube - System Center: Colored background remained visible when no filter was applied on the Logging page \[ID_25316\]

When, on the Logging page in System Center, you apply a filter, the background turns blue to indicate that you are viewing a filtered list. In some cases, the background would remain blue after the filter had been removed.

#### DataMiner Cube - Correlation: New analyzer would incorrectly be created when opening the Correlation app via a workspace \[ID_25320\]

When you opened the *Correlation* app by opening a workspace, in some cases, the *Analyzers* tab would be selected and a new analyzer would incorrectly be created.

#### Service & Resource Management: When a resource was updated, usages of other resources would incorrectly also be quarantined \[ID_25322\]

When, for a particular resource, a capacity or capability was deleted or a capability was downgraded, not only would all usages of that resource be quarantined, but also all usages of other resources using the same capacity or capability profile as the one used by the resource that was updated.

#### Problem with subscriptions on virtual functions \[ID_25326\]

In some cases, subscriptions on virtual functions would not return the correct data.

#### Dashboards app - Service definition component: System function nodes did not show images \[ID_25329\]

In some cases, images would be missing from system function nodes displayed on a service definition component.

#### Problem with duplicate trend data points when retrieving real-time trend data from a MySQL database \[ID_25337\]

When real-time trend data was retrieved from a MySQL database, in some cases, duplicate trend data points could incorrectly be returned.

#### DataMiner Cube - EPM: Filters would not correctly handle user filter and partial table pages when linked to a diagram \[ID_25339\]

In some cases, EPM filters linked to a diagram would not correctly handle partial table pages and user filters. Only the first page of the result set would be loaded into the selection box, and a custom filter entered by the user would not be applied.

#### When a function resource was deleted, its row in the \[Generic DVE Linker Table\] would incorrectly not be removed \[ID_25356\]

When a function resource is created, a row is added to both the \[Generic DVE Table\] and the \[Generic DVE Linker table\]. When a function resource was deleted, in some cases, only the row in the \[Generic DVE Table\] was deleted. The row in the \[Generic DVE Linker table\] would incorrectly not get deleted.

#### Problem with interface properties of DVE elements \[ID_25360\]

When, in the DataMiner Connectivity Framework page of the General Parameters of an element, the \[Interface Properties\] table was updated, in some cases, some of the information in that table would not get synchronized correctly to the interfaces of the Virtual Function elements when linking them.

#### DataMiner Cube - Trending: Problem when export a trend graph to a CSV file \[ID_25369\]

When you exported a trend graph to a CSV file, in some cases, that CSV file would be formatted incorrectly, especially when the exported graph contained multiple lines.

#### Invalid alarm levels were passed to the parent items when bubble-up severity was identical to that of the table row and one of them got cleared \[ID_25383\]

When the bubble-up severity was identical to that of the table row itself, and one of those was cleared, in some cases, an invalid alarm level would be passed to the parent items.

#### Web Services API v0: GetActiveAlarmsFromView SOAP call would return alarms from parameters not included in the services found in the specified view \[ID_25391\]

When a GetActiveAlarmsFromView SOAP call was performed, all alarms of all elements in the services found in the specified view would be returned, even those associated with parameters that were not included in the services in question.

#### Element connections: Problem with 'Include element state' option \[ID_25418\]

In the *Element Connections* app, in some cases, the states of the source element would incorrectly be passed to the destination element(s) when the *Include element state* option was not selected.

#### Format exception in SLNet.txt log file \[ID_25427\]

In some cases, a FormatException would be added to the SLNet.txt log file.

#### DataMiner Cube - Services app: Problem when dragging and dropping in a service definition diagram \[ID_25434\]

In the *Services* app, in some rare cases, an exception could be thrown when performing drag and drop operations in a service definition diagram.

#### Service & Resource Management: No longer possible to save a service definition with an empty diagram \[ID_25439\]

In the Services app, in some cases, it was no longer possible to save a service definition with an empty diagram.

#### Alarm templates: Monitoring conditions would not get re-evaluated after a row or table update \[ID_25453\]

When, in an alarm template, conditional monitoring was configured, in some cases, conditions would not get re-evaluated after a row or table update.

#### Problem with SLDataMiner \[ID_25458\]

In some rare cases, an *OwnershipUpdateThread* error could occur in SLDataMiner.

#### DataMiner Cube - Visual Overview: Problem with FollowPathColor option \[ID_25460\]

In some rare cases, the *FollowPathColor* option would not get applied, especially when the connection lines ran between interfaces with an undefined alarm level state while the parent element had a different state.

#### DataMiner Cube: Inconsistent user initials \[ID_25464\]

Up to now, in some cases, user initials in DataMiner Cube would be inconsistent. Now, user initials will always be the first letters of the full name.

Note that, by design, the user selector at the bottom of the login screen will still display only one letter (i.e. the first letter of the full name).

#### DataMiner Cube - Services app: Items in diagram would still appear to be selected after switching from one tab to another \[ID_25468\]

When, in the Services app, you switched from one tab to another, in some cases, the items selected in the diagram would still appear to be selected although they were not.

#### DataMiner Cube - Data Display: Problem with filtering on discreet or numerical column parameters using wildcards \[ID_25472\]

In some cases, it would no longer be possible to filter on discreet or numerical column parameters using wildcards.

#### DataMiner Cube: Element/service not visible if moved from inaccessible view \[ID_25474\]

If an element or service was created in a view to which a particular user did not have access and then moved to a view to which that user did have access, it could occur that the user could not see the element or service until Cube was reloaded.

#### Dashboards app - Service definition component: Script parameters were swapped \[ID_25476\]

When a script was launched from the service definition component, in some cases, the booking ID (or the service definition ID) and the node ID script parameters would be swapped.

#### Problem when MaintenanceSettings.xml contained Trending tag without TimeSpan tag \[ID_25478\]

If the *MaintenanceSettings.xml* file contained a *Trending* tag that did not contain a *TimeSpan* tag, a problem could occur with the file.

#### Monitoring app: Problem when viewing a trend histogram for a column parameter with a primary key containing lowercase characters \[ID_25481\]

In the Monitoring app, in some cases, no data would be returned when viewing a trend histogram for a column parameter with a primary key containing lowercase characters.

#### Dashboards app - Parameter feed: Bottom arrow not displayed when 100 indices had been loaded \[ID_25492\]

When, in the parameter feed component, you had loaded 100 indices, the bottom arrow to load more indices would not be displayed.

#### DataMiner Cube - Element Connections: Problems with table parameters \[ID_25496\]

In the *Element Connections* app, in some cases, issues could occur with regard to table column parameters. Some rows would not disappear after being deleted and some rows would be missing data.

#### DataMiner Cube - Data Display: Zero-width column was not saved at the correct position when saving the column layout of a table \[ID_25534\]

When you saved the column layout of a table that contained a hidden column (i.e. a column of which the width was set to 0 in the protocol), that hidden column would not be saved at the correct position.

#### Web Services API v0/v1: Methods would return parameters to which users had not been granted access \[ID_25544\]

Some of the web methods would incorrectly return parameters to which users had not been granted access. From now on, a number of parameter-related methods will also require the “SDElementOverview” flag.

Also, the GetTableForParameterV2 method would incorrectly return table columns that had “width=0” defined in the protocol, and, in some cases, it would incorrectly be possible to update a parameter of an element marked as “read only”.

#### Problem with SLPort due to a buffer resizing issue \[ID_25607\]

When SLPort receives data, it stores it in a buffer until everything has been received. If the amount of data received is larger than the size of the buffer, the buffer is automatically resized. However, in some cases, this would not happen, causing an error to occur.
