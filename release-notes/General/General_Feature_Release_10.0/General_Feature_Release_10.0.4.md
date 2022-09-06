---
uid: General_Feature_Release_10.0.4
---

# General Feature Release 10.0.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### DBMaintenanceDMS.xml: TTL settings can now be specified for all custom data types defined in an Elastic database \[ID_24846\]

In the *DBMaintenanceDMS.xml* file, you can now configure “time to live” (TTL) settings for all custom data types defined in an Elastic database.

In the following example, a TTL setting was specified for job objects stored in an Elastic database:

```xml
<MaintenanceConfigs>
  <MaintenanceConfig type="DMS" xmlns="http://www.skyline.be/config/dbmaintenance">
    <TimeToLive>
      <TTL type="cjobsection">
        <Indexing>6M</Indexing>
      </TTL>
      ...
    </TimeToLive>
  </MaintenanceConfig>
</MaintenanceConfigs>
```

### DMS Cube

#### Logging: Setting log levels per DataMiner log file \[ID_23244\]\[ID_24771\]

In the *Logging* section of *System Center*, it is now possible to set log levels per DataMiner log file, overriding the ones specified on system level.

##### Overriding the system-wide log levels for a specific log file

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the log file in the left-hand pane.

1. At the top of the right-hand pane, open the *Log settings* section, select the *Override log levels* option, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

> [!NOTE]
>
> - If you want to set the same non-default log levels for multiple log files, then note that you can select more than one file in step 1. To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.
> - In the left-hand pane, the current log levels for each of the DataMiner log files are displayed next to the name of the file.
>   - If a file inherits the system-wide log levels, the log levels displayed next to the file will appear in gray.
>   - If a file has specific log levels defined (i.e. if the system-wide levels are overridden), the log levels displayed next to the file will appear in black.
> - If you clear the *Override log levels* option for a particular log file, that file will again inherit the system-wide log levels.

##### Setting the system-wide log levels

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the first entry in the left-hand pane, marked “\<Default>”.
1. At the top of the right-hand pane, open the *Log settings* section, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

#### Service & Resource Management - ListView: Alarm count column can now indicate the number of alarms as a colored icon \[ID_24598\]

In the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, the *Alarm count* column can now be configured to indicate the number of alarms as an icon taking the color of the most severe alarm.

#### New setting to display a Forward button in card header bar menus \[ID_24844\]

In the new Cube X layout, by default, cards no longer have a Forward button in their header bar menu.

If you want card header bar menus to contain a Forward button, then open the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file, and set the *commonServer.card.DisplayForwardButton* option to true.

#### Visual Overview: New icons added to DataMiner stencils \[ID_25024\]

The following additional icons are now available in the DataMiner stencils:

- PTP -BC
- PTP-TC
- PTP-Slave
- PTP-GrandMaster

### DMS Reports & Dashboards

#### Legacy Reporter app will now also use the CSV separator specified in Cube’s CSV separator setting \[ID_24855\]

Similar to the new Dashboards app, the legacy Reporter app will now also use the CSV separator specified in Cube’s “CSV separator” setting when generating CSV reports.

If this setting cannot be retrieved, the system will fall back to the Windows regional settings on the DataMiner Agent.

### DMS Mobile apps

#### Jobs app: Filtering on auto-increment fields \[ID_24047\]\[ID_24857\]\[ID_25057\]

Up to now, a job’s auto-increment field was of type Long and could not be used to filter on. Now, that field will be of type String, containing an ID with a prefix and a suffix. As a result, it will now be possible to filter on it.

> [!NOTE]
> This change requires all existing job data to be converted. This data will automatically be converted the first time you start a DataMiner Agent after upgrading it. However, note that this means that data may be lost if you downgrade to earlier DataMiner versions.

#### Jobs app: Format of auto-increment fields can now be changed even when those fields are being used in existing jobs \[ID_24917\]\[ID_24973\]

From now on, it is allowed to change the format of auto-increment fields even when those fields are being used in existing jobs. However, you will receive a notice, saying that existing jobs will keep using the old format.

#### Monitoring app: Spectrum Analyzer elements now have a Spectrum Analyzer page \[ID_24925\]

In the Monitoring app, Spectrum Analyzer elements now have a Spectrum Analyzer page that shows the spectrum trace, using a new monitor with the last preset.

#### DataMiner landing page: Drop-down menu that allows to install the DataMiner Cube desktop application \[ID_25017\]

The DataMiner landing page now contains a drop-down menu on the right that allows you to install the DataMiner Cube desktop application using either a click-once web installer or an MSI installer.

### DMS Service & Resource Management

#### Service profiles \[ID_24552\]

Up to now, when users wanted to configure a service reservation, they each time had to select profiles for every node and interface of the service definition. From now on, when configuring a service reservation, users will in most cases only have to select a single predefined service profile. That profile will then automatically configure most of the nodes and interfaces necessary for the service reservation in question.

> [!NOTE]
>
> - You can define a single service profile for a series of almost identical service definitions.
> - Service profile logging is stored in SLProfileManager.txt.
> - To make sure service profile data is included in DataMiner backup packages, select *Profile Manager objects and configuration* when configuring backups in System Center.

#### OnStartActionsFailureEvent will now be executed when the start actions of a ReservationInstance fail \[ID_24790\]

From now on, an OnStartActionsFailureEvent will be executed when the start actions of a ReservationInstance fail.

If you want to use this event to trigger an Automation script, then make sure to add a custom entry point method to that script. See the example below.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmStartActionsFailure)]
public void OnSrmStartActionsFailure(Engine engine, List<StartActionsFailureErrorData> errorData)
{
}
```

A StartActionsFailureErrorData instance contains an *ErrorReason*, which explains what went wrong with the start actions. These are the possible error reasons:

- **ResourceElementNotActive**: The element linked to the resource was not active when the booking was started.

  > [!NOTE]
  > The resource (as well as the element ID) can be retrieved from the *Resource* property. The ReservationInstanceId will also be filled in.

- **ReservationInstanceNotFound**: The ReservationInstance could not be retrieved when the start actions were launched.

- **UnexpectedException**: An exception was thrown while executing the start actions.

  > [!NOTE]
  > This exception can be retrieved from the Exception property. The ReservationInstanceId is available in the ErrorData object.

##### Assigning an Automation script to the OnStartActionsFailureEvent

The following example shows how to assign an Automation script to the OnStartActionsFailureEvent.

```csharp
reservationInstance.OnStartActionsFailureEvent = new ReservationEvent("OnStartActionsFailureEvent", $"Script:StartActionsFailedScript");
```

Although the event name can be chosen randomly, it should be a meaningful name, as it can appear in log entries.

Notes:

- From now on, the elements linked to the resource must be active when the booking is started.

- The start actions will only be started after the ResourceManager has tried to activate the function resources.

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent was configured. See the following example:

    ```txt
    The start actions for the ReservationInstance 'c3c6df39-bf28-4860-b426-a6dcb2d2306f - RT_SRM_OnStartActionsFailureEvent_08_59_20' have failed, but no OnStartActionsFailure event was configured.
    ```

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent script has been configured. See the following example:

    ```txt
    The script Script:THIS_SCRIPT_DOES_NOT_EXIST_d03c6ec0-3274-4d01-8b28-e4d12459520d could not be correctly parsed to an existing automation script. The event OnStartActionsFailureEvent of reservation '4ce12a06-55f4-4c7c-a746-7874b23ecd8d - RT_SRM_OnStartActionsFailureEvent_08_59_00' will not be executed.
    ```

#### DataMiner upgrade: Additional action to correct default value types of profile parameters \[ID_24937\]

As it is no longer allowed for profile parameters with a type set to a value other than “Undefined” to have a default value of type “Undefined”, when upgrading to DataMiner 10.0.0/10.0.4, an additional action will be performed to correct all incorrect default value types.

Whenever a profile parameter with a type set to a value other than “Undefined” has a default value of type “Undefined”, the upgrade action will do the following:

| If...                                        | then...                                                                                                                                                                                 |
|----------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| the profile parameter is of type “Number”,   | the type of the default value will be set to “Double”.                                                                                                                                  |
| the profile parameter is of type “Text”,     | the type of the default value will be set to “String”.                                                                                                                                  |
| the profile parameter is of type “Discreet”, | If the parameter’s “DiscreetDisplayValues” list is filled in, then the type of the default value will be set to “Discreet”, else the type of the default value will be set to “String”. |

> [!NOTE]
> The upgrade action will create a backup copy of the profiles.xml file named profiles.xml.bak, and will store in the C:\\Skyline DataMiner\\ProfileManager\\changeundefinedtype_backup\\ folder.
>
> This backup copy will not be deleted when the upgrade action has finished.

## Changes in DataMiner 10.0.4

### Enhancements

#### SLNet: Enhanced alarm sorting \[ID_22739\]

A number of enhancements have been made to the alarm sorting mechanisms in the SLNet process.

Current alarm levels (in order of increasing priority):

- Undefined
- Initial
- Suggestion
- Information
- Normal
- Masked
- Notice
- Warning
- Minor
- Major
- Critical
- Timeout
- Error

#### A notice will now be generated when the parameter update stack of SLElement exceeds 5000 items \[ID_24259\]\[ID_24980\]

A notice will now be generated a minute after the parameter update stack of SLElement has exceeded 5000 items.

As soon as the number of items in that stack drops below 1000, the notice will be cleared automatically.

#### DataMiner Cube - Alarm Console: Enhanced performance when adding property columns \[ID_24545\]

Due to a number of enhancements, performance has increased when adding property columns in alarm tab pages.

#### DataMiner installer will no longer install Web Services Enhancements \[ID_24547\]

From now on, the DataMiner installer will no longer install Web Services Enhancements for Microsoft .NET.

#### Logging related to smart baselines will now be added to a dedicated log file \[ID_24627\]

Up to now, all logging related to smart baselines was added to the *SLNet.txt* log file. From now on, this logging will be added to the *SLSmartBaselineManager.txt* file instead.

#### Cassandra database: Cluster name in cassandra.yaml file now always set to 'DMS' \[ID_24645\]

In a cassandra.yaml file, the Cassandra cluster name will no longer be configurable. It will now always be set to “DMS”.

> [!NOTE]
> The Cassandra cluster name is not linked to the DMS cluster name. The latter is still configurable.

#### Jobs app: Fields marked 'Show in list view' will now always be shown in the jobs list, even when those fields do not have values \[ID_24708\]

Fields that are marked “Show in list view” will now always be shown in the jobs list, even when none of the listed jobs have a value set in those fields.

#### Migrating booking data to Indexing Engine: 'Show all properties' option will now by default not be selected \[ID_24717\]

When migrating booking data to Indexing Engine, up to now, the “Show all properties” option would be selected even when there were no properties to be changed. From now on, this option will by default not be selected.

#### DataMiner Analytics: Enhanced SLNet subscription management \[ID_24730\]

A number of enhancements have been made to the way in which DataMiner Analytics manages SLNet subscriptions.

#### DataMiner Cube - Service & Resource Management: ListView enhancements \[ID_24736\]

A number of enhancements have been made to the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview:

- The *Add/Remove Column \> More…* shortcut menu option was moved up one level and renamed to *Manage column configuration…*
- The title of the column configuration window, which was named *Choose details*, has now been renamed to *Column configuration*.

#### HTML5 apps: Enhanced installation \[ID_24745\]

A number of enhancements have been made to the DataMiner HTML5 apps (e.g. Jobs, Dashboards, etc.). Users will now be able to install these apps much like they install other mobile apps.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents associated with alarms of elements that are paused or stopped will no longer be cleared \[ID_24750\]

From now on, events associated with alarms of elements that are paused or stopped will no longer be cleared.

#### DataMiner Cube - Services list: Only state change icons configured to perform a valid state change will be clickable \[ID_24753\]

When life cycle management is enabled, then the services list allows you to change the state of the service by clicking an icon. From now on, you will only be able to click icons that are configured to perform a valid state change.

#### DataMiner Cube - Visual Overview: Advanced editing pane improvements \[ID_24772\]\[ID_24794\]

The “Advanced Editing” pane now provides better support for DataMiner stencils.

From now on, this pane will

- no longer display shape data that is marked “hidden”, and
- no longer show underlying formulas in shape data, but the actual value.

Also, a few general enhancements have been made with regard to scrolling and keyboard focus.

#### Enhanced performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) \[ID_24777\]

Due to a number of enhancements, overall performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) has increased, especially when updating matrix data.

#### Monitoring app & Dashboards app: Parameter tables can now be displayed in full-screen mode \[ID_24789\]\[ID_24830\]

In the Monitoring app (DATA pages, VISUAL pages and CPE pages) and the Dashboards app (Parameter Page component), parameter tables can now be displayed in full-screen mode.

If your internet browser supports full-screen mode, a toggle button will appear in the top-right corner of each parameter table. You can exit full-screen mode by pressing ESC or F11.

#### DataMiner Cube - Service & Resource Management: Property columns will now automatically be updated upon property changes \[ID_24826\]

In ListView components embedded in Visio pages, from now on, columns referring to element properties will automatically be updated upon property changes.

#### DataMiner Cube - Alarm Console: Element state changes no longer trigger a refresh of filtered alarm tab pages \[ID_24832\]

Up to now, element state changes would trigger a refresh of filtered alarm tab pages. From now on, this will no longer happen.

#### Web Services API v1: Enhanced retrieval of trend data \[ID_24848\]

From now on, the GetTrendDataForTableParameter and GetTrendDataForTableParameterV2 methods will automatically try to retrieve real-time trend data when no average trend data is available (and vice versa).

#### DataMiner Cube will now be shipped with Segoe MDL2 Assets font \[ID_24853\]

Because client computers running a Microsoft Windows version prior to Windows 10 do not have the Segoe MDL2 Assets font installed by default, from now on, that font will be shipped with DataMiner Cube.

#### SLDMS: SLElement/SLDMS throttle removed \[ID_24862\]

Previously, the amount of simultaneous calls that native SLElement and SLDMS modules could make to the local SLNet process was limited to 1 and 5 respectively. This limit has now been removed. Both now use the same limit as other processes, i.e. 10 simultaneous calls.

If you prefer to keep the call limits as they were, you can specify the following option in the *\<appSettings>* section of the *C:\\Skyline DataMiner\\Files\\SLNetCOM.dll.config* file:

```xml
<add key="UseLegacyThrottle" value="true" />
```

When you set this *UseLegacyThrottle* option to true, the Application/DataMiner event viewer log will show entries for SLElement.exe and SLDMS.exe indicating “Applied throttle: 1” (SLElement) or “Applied throttle: 5” (SLDMS).

#### HTML5 apps: Enhancement date/time selector \[ID_24912\]

In all HTML5 apps (Monitoring, Dashboards, Ticketing, etc.), the date/time selector has been enhanced. It is now also possible to confirm the time by double-clicking the minutes.

#### DataMiner Cube: Option to connect over Web Services will now be hidden when Web Services Enhancements is not installed on the DataMiner Agent \[ID_24918\]

When you try to connect to a DataMiner Agent that does not have Web Services Enhancements for Microsoft .NET installed, from now on, you will no longer be able to set *Connection type* to “Web services” in the logon options window of DataMiner Cube.

#### DataMiner Cube: Undocked cards now have an updated DataMiner logo in the upper-left corner \[ID_24920\]

Undocked cards now have an updated DataMiner logo in the upper-left corner.

#### Indexing Engine: A search string will only be added to the list of suggestions when the search yields results \[ID_24927\]

When, on a system with an Indexing Engine, you perform a search, from now on, the search string you entered will only be added to the list of suggestions when the search yields results.

#### DataMiner Cube - Alarm Console: Enhanced performance when displaying parameter heat lines \[ID_24928\]

Due to a number of enhancements, overall performance has increased when displaying parameter heat lines in the Alarm Console.

#### DataMiner Analytics - Alarm focus: Enhanced likelihood calculation of alarms associated with elements that were paused or stopped \[ID_24931\]

A number of enhancements have been made to the alarm focus mechanism, especially with respect to the likelihood calculation of alarms associated with elements that were paused or stopped.

#### SLDMS: Enhanced file locking mechanism \[ID_24954\]

A number of enhancements have been made to the file locking mechanism in SLDMS.

### Fixes

#### Properties on DVE child element lost after assigning alarm or trend template \[ID_16528\]

In some cases, when a new alarm or trend template was assigned to a DVE child element, properties on that element could be lost.

#### DataMiner Cube - Protocols & Templates: Problem when trying to select another protocol version in the 'List based on protocol version' box \[ID_24499\]

If an information template is based on an older protocol version that does not have the same parameters as the latest protocol version, a warning is displayed at the bottom of the information template. Above the warning, a drop-down list allows you to select a different protocol version to load those parameters instead.

In some cases, selecting a different protocol version in this drop-down list would no longer be possible.

#### DataMiner Cube - Services app: Problem when duplicating service definitions \[ID_24500\]

In some cases, when duplicating a service definition, some data would not get copied to the newly created duplicate.

#### Alarm level linking would not be initialized or updated correctly \[ID_24509\]

In some cases, alarm level linking would not be initialized or updated correctly.

#### Failover: 'AlwaysBruteForceOffline' option would not work correctly when releasing virtual IP addresses took more than 10 seconds \[ID_24535\]

When a Failover setup with the *AlwaysBruteForceOffline* option enabled had to go offline, in some cases, the agent would not be restarted when releasing the virtual IP addresses took more than 10 seconds. The agent would incorrectly remain in an undefined state. Also, when the agent eventually went online at a later stage, problems could occur. On systems with a MySQL database, for example, incorrect element alarms would start to appear.

#### Problem with file synchronization cache \[ID_24620\]

Due to a problem with the file synchronization cache, in some cases, old file versions could incorrectly get synchronized again among the agents in a DataMiner System.

#### Migrating booking data to Indexing Engine: Incorrect message in case of successful migration \[ID_24671\]

When a booking data migration to Indexing Engine completed successfully, up to now, the following incorrect message would appear:

```txt
The migration is done with 0 failed merge(s), but without exceptions or errors.
```

From now on, the following message will appear instead:

```txt
The migration has successfully been completed.
```

#### DataMiner Cube - Alarm Console: Not possible to have the 'Focus' column displayed in 'active alarms' tabs listing different types of alarms and events \[ID_24680\]

In an “active alarms” tab showing masked alarms, non-masked alarms, information events and suggestion events, in some cases, it would not be possible to have the Focus column displayed.

#### Problems with recursive tables \[ID_24683\]

When a recursive table was queried directly using dynamic table queries, incorrect results would be returned when a “FK=xxx” filter was used on that same recursive table.

Also, when an element with bubble-up alarms in a recursive table was restarted, some of those alarms would incorrectly be counted twice. This would produce incorrect results when alarm severities dropped.

#### DataMiner Cube - Trending: Problem when exporting trend data to CSV while trend logging was disabled \[ID_24699\]

When you exported a trend graph to a CSV file after selecting the *Everything* option, in some cases, none or only part of the trend data would get exported when trend logging was disabled. Also, afterwards, data could be missing from the trend graph when selecting e.g. “Previous month”.

#### DataMiner Cube - Bookings app: Problem when zooming to last/next month in the bookings timeline \[ID_24704\]

When, in the bookings timeline, you zoomed to last/next month, in some cases, the timeline would zoom to an incorrect time range (e.g. one day).

#### DataMiner Cube - Services app: Problem with service definition diagram updates \[ID_24707\]

In the *Services* app, in some cases, the diagram of a service definition would not be updated properly when the service definition was embedded on a Visio page and the *AutoLoadExternalChanges* option was set to true.

#### Problem with SLDMS when synchronizing services to other agents \[ID_24725\]

In some rare cases, an error could occur in SLDMS when synchronizing services to other agents in the DataMiner System.

#### DataMiner Cube - Data Display: Problem with lite drop-down controls when the listed parameter values were dependent on other parameter values \[ID_24743\]

In some cases, lite drop-down controls would not contain the correct values, especially when the listed parameter values were dependent on other parameter values.

#### Problem when writing multiple datasets to a database \[ID_24748\]

When multiple datasets were written to a database in one go, e.g. when inserting data temporarily stored in offload files, in some cases, the following exception could be thrown:

```txt
System.InvalidOperationException: Collection was modified after the enumerator was instantiated.
```

#### DataMiner Cube - Advanced search: Problem when matches could only be found for one of the state filter options \[ID_24758\]

When, in the advanced search, you filter by item type (e.g. “Element”), an additional state filter appears. When you selected that state filter, in some cases, Cube would stop working when matches could only be found for one of the state filter options.

#### DataMiner Installer: Problem when installing a DataMiner Agent with a Cassandra database \[ID_24762\]

In some cases, the DataMiner Installer would fail to install a DataMiner Agent with a Cassandra database.

#### DataMiner Cube - Data Display: Description of Write parameters would be missing when there was no corresponding Read parameter \[ID_24767\]

On an element card, in some cases, Write parameters for which there was no corresponding Read parameter would not have their description displayed.

#### DataMiner Cube - Router Control: Problem when loading tab page IO buttons in configuration mode \[ID_24779\]

When, in configuration mode, the first tab of a tab control was loaded, in some cases, the IO buttons in that tab would not be loaded.

#### DataMiner Cube: Redesigned Cube X alarm icons incorrectly indicated timeouts and did not fully support alarm severity capping \[ID_24785\]

In DataMiner Cube, in some cases, the redesigned Cube X alarm icons would incorrectly indicate timeouts, especially for items included in a service. Also, up to now, those alarm icons would not fully support alarm severity capping.

#### Ticketing app: Problem when opening the app \[ID_24786\]

When opening the Ticketing app, in some cases, the following error could be thrown:

```txt
Error trapped: An entry with the same key already exists.
```

#### Problem when taking agents out of a Failover setup with a Cassandra database \[ID_24787\]

In some cases, it would no longer be possible to correctly take an agent out of a Failover setup with a Cassandra database.

#### DataMiner Cube - Data Display: Problem when searching for a parameter in an element card \[ID_24801\]

In some cases, DataMiner Cube would become unresponsive when, in an element card, you searched for a parameter using the search box in the top-left corner of the card.

#### Problem when performing a full synchronization \[ID_24804\]

When performing a full synchronization, in some cases, an error could occur due to a deadlock in SLDataMiner.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would no longer get updated properly \[ID_24808\]

In some cases, a ListView component embedded on a Visio page would no longer get updated properly.

#### DataMiner Cube - Visual Overview: Trend components with dynamic shape data could no longer be collapsed \[ID_24812\]

In some cases, trend components with dynamic shape data could no longer be collapsed.

#### DataMiner Cube - Service & Resource Management: Column headers in ListView components could lose their filter and sort controls \[ID_24814\]

In a ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, in some cases, column headers could lose their filter and sort controls.

#### Jobs app: Problem when using the search box \[ID_24817\]

When, in the Jobs app, you used the search box, in some cases, the ElasticSearch database would throw an exception.

#### DataMiner Cube: Sidebar would stay invisible until Cube window was resized \[ID_24819\]

When you log in to a DataMiner Cube of which the sidebar was collapsed, in some cases, the sidebar would stay invisible until the entire Cube window was resized.

#### HTML5 apps: Value changes made by the program were not detected \[ID_24822\]

When, in an HTML5 app, a value had been updated manually, in some cases, the input control would not take into account subsequent updates of that same value made by the program.

#### When an unmonitored element in timeout was masked and then unmasked when it was no longer in timeout, its alarm state would be set to 'normal' instead of 'undefined' \[ID_24838\]

When an unmonitored element in timeout was masked and then unmasked after it had gone out of timeout, its alarm state would incorrectly be set to “normal” instead of “undefined/not monitored”.

#### DataMiner Cube: Problem when initializing the Element Connections module \[ID_24847\]

In some rare cases, an exception could be thrown when the Element Connections module was being initialized.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would incorrectly display booking property updates \[ID_24854\]

In some cases, a ListView component embedded on a Visio page would not correctly display booking property updates.

#### DataMiner Cube - Trending: Problem when exporting real-time trend data to CSV using the 'Line graph' option \[ID_24861\]

When you exported real-time trend data to CSV with the *Line graph instead of block graph* option selected, in some cases, no intermediary points would be added if no data was available at certain timestamps.

Also, points that fell outside of the selected time range would not get exported.

#### 'Address length of 0' error added to SLErrors.txt when loopback network adapters were found during a DataMiner startup \[ID_24864\]

When DataMiner was started on a system with loopback network adapters, the following error would be added to the SLErrors.txt log file:

```txt
L::GetLocalMAC|ERR|-1|Address length of 0
```

#### DataMiner Cube: Problem when entering special characters in header search box \[ID_24869\]

When, in the header search box, you searched for special characters (e.g. “++”), no results would be returned, even when results were available.

#### DataMiner Maps: Problem retrieving the alarm level for a marker from a column different from the primary key \[ID_24870\]

In some cases, it would no longer be possible to retrieve the alarm level for a marker from a column different from the primary key.

#### Problem when an element was stopped while an alarm time trace was being written \[ID_24872\]

In some rare cases, an error could occur when an element was stopped while a time trace was being written for one of its alarms.

#### DataMiner Cube: Collapsing the sidebar would cause it to go into an invalid state \[ID_24877\]

In some cases, collapsing the sidebar would cause it to go into an invalid state.

#### Jobs app: Save button could no longer be clicked after trying to save a job that contained errors \[ID_24881\]

After trying to save a job that contained errors (e.g. missing fields), in some cases, it would no longer be possible to click the *Save* button again after correcting the errors.

#### Problem when calling GetParameter on the virtual element of a redundancy group \[ID_24892\]

When a GetParameter method was called in an Automation script on the virtual element of a redundancy group, in some cases, a CreateDummyFailedException could be thrown.

#### Db.xml: 'oldstyle' argument of \<Offload> tags would be removed when database settings were updated via Cube \[ID_24895\]

When a user had manually specified an *oldstyle* argument in an *\<Offload>* tag of the *Db.xml* file, that argument would be removed the first time the central database settings were updated via DataMiner Cube. From now on, Cube will no longer remove manually added *oldstyle* arguments.

#### 'Unknown Parameter: Rollback' notice when installing Cassandra or Indexing Engine \[ID_24913\]

During a Cassandra or Indexing Engine installation, in some cases, an “Unknown parameter: NoRollback” notice would be generated.

From now on, upgrade packages will ignore the “SetOption NoRollback” command and will add an “info” line to the log saying “Ignoring NoRollback option (legacy)”.

#### Memory leak in SLNet when enabling or disabling logging \[ID_24921\]

In some cases, the SLNet process would leak memory when logging was enabled or disabled.

#### DataMiner Cube: 'Spectrum settings:' label incorrectly displayed on 'Advanced element settings' pane of element without Spectrum Analyzer settings \[ID_24956\]

When editing an element without any Spectrum Analyzer settings, in some cases, when you opened the *Advanced element settings* pane, a “Spectrum settings:” label would incorrectly be displayed at the bottom of the pane.

#### Deleting a monitored table row could cause an incorrect alarm to be generated \[ID_24957\]

When a monitored table row was deleted, in some cases, an incorrect alarm with an invalid root ID and invalid time stamp would be generated.

#### Problem with SLDataGateway when installing Indexing Engine \[ID_24969\]

In some cases, an error could occur in SLDataGateway when installing Indexing Engine.

#### Problem with SLDMS when synchronizing a file with a name containing percentage character while the log level was set to 5 or 6 \[ID_24985\]

During a midnight synchronization, in some cases, an error could occur in the SLDMS process when a file with a name containing “%” was being synchronized while the log level was set to 5 or 6.

#### DataMiner Cube - Services app: Selected node, edge or interface would no longer be selected after a service definition was refreshed \[ID_24994\]

When, in the Services app, a service definition was refreshed, in some cases, the node, edge or interface that was selected before the refresh would no longer be selected after the refresh.

#### DataMiner Cube: Newly created service not selected in card breadcrumbs \[ID_25005\]

When you created a new service, in some rare cases, the name of that service would incorrectly not be selected in the breadcrumbs of the service card.

#### CPE Management: Problem when resolving recursively linked keys \[ID_25023\]

In some cases, recursively linked keys would be resolved incorrectly. This would especially affect the retrieval of CPE data (e.g. alarm properties).

#### Jobs app: No headers were displayed at the top of the jobs list \[ID_25042\]

In the Jobs app, in some cases, no headers would be displayed at the top of the jobs list.

#### Problem with booking after property update \[ID_25076\]

When a property of a booking was updated using the method *SafelyUpdateReservationInstanceProperties*, a problem could occur with the booking.

#### Jobs app: Problem listing the job section definitions \[ID_25087\]

In the Jobs app, in some cases, an error would occur when trying to list the job section definitions.

#### CRC trailer from separate IP packet not added to response \[ID_25089\]

If a CRC trailer was returned in a separate IP packet, it could occur that it was not added to the response.

## Changes in DataMiner 10.0.4 CU1

### CU1 fixes

#### Ticketing app: Deleting a ticket would incorrectly cause all tickets to be deleted \[ID_25211\]

In some cases, deleting a ticket would incorrectly cause all tickets to be deleted.

#### ReservationInstance property updates would not get saved to the database when a DMS consisted of a single DMA \[ID_25221\]

When a DataMiner System consisted of a single DataMiner Agent, in some cases, ReservationInstance property updates would not get saved to the database.

## Changes in DataMiner 10.0.4 CU2

### CU2 fixes

#### Memory leak in SLDataGateway \[ID_25395\]

When DVE elements had average trending configured while the central database was enabled, in some cases, the SLDataGateway process would leak memory.
