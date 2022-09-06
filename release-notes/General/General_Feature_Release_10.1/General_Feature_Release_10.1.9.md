---
uid: General_Feature_Release_10.1.9
---

# General Feature Release 10.1.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Improved SLLog stack cleaning behavior \[ID_29989\]

The way the SLLog process cleans the log file stack has been improved. SLLog now has a thread that iterates over the different log file buffers and that logs a number of lines from the buffers to the log files. The maximum number of lines depends on the *LinesPerIteration* setting in *LogSettings.xml* (default: 100).

In addition, SLLog now monitors its own memory usage, and whenever the memory usage exceeds a specific threshold, it will clean up the largest stack that has not yet been written to a file. This threshold is determined by the *SLLogMaxMemorysetting* in *LogSettings.xml* (default: 500 MB). For this setting, you can only specify integer numbers, which correspond with a number of megabytes.

*LogSettings.xml* can for instance be configured as follows:

```xml
<Log xmlns="http://www.skyline.be/config/log">
   <File name="">
      <Levels info="0" error="0" debug="0" />
   </File>
   <General>
      <LinesPerIteration>50</LinesPerIteration>
      <SLLogMaxMemory>100</SLLogMaxMemory>
   </General>
</Log>
```

#### DataMiner Object Model: DomInstanceNameDefinition \[ID_30226\]

A ModuleSettings object now has a DomInstanceNameDefinition property, which allows you to define how the name property of a DomInstance should be filled in automatically each time the instance is saved.

The DomInstanceNameDefinition class can contain a list of IDomInstanceConcatenationItems, which, placed in a specific order, will define the DomInstance name.

Currently, there are two types of concatenation items:

- **StaticValueConcatenationItem**

    Used to define a fixed string to be inserted into the DomInstance name.

    The string value should be assigned to the ‘Value’ property.

- **FieldValueConcatenationItem**

    Used to define a FieldValue (defined on a DomInstance) to be inserted into the DomInstance name.

    The FieldDescriptorID of the FieldValue should be assigned to the FieldDescriptorId property. When no FieldValue can be found with the given FieldDescriptorId, an empty string will be inserted instead.

    A FieldValue can contain a variety of non-string data types. See below for more information on how these types will be converted to strings:

    | FieldValue type | Example of how this type will be converted to a string |
    |-------------------|--------------------------------------------------------|
    | Guid              | ‘bc77dcb5-b523-4722-aaaa-7d99a5c82304’                 |
    | double            | ‘124.65’                                               |
    | long/int          | ‘15254876’                                             |
    | DateTime          | ‘1997-04-10T14:40:14.0000000Z’ (ISO8601)               |
    | TimeSpan          | ‘13:28:18.9187335’                                     |
    | bool              | ‘True’                                                 |
    | GenericEnumEntry  | ‘SomeDisplayValue’ (the DisplayValue will be used)     |

##### Example

In the following example, we want to create DomInstances for switches in a network and created FieldDescriptors for the following data:

- Switch brand
- Switch model
- Management IP
- Year of installation

The names of the DomInstances, which will each represent a switch, have to contain all this information (example: “Cisco C9500-24Y4C - 10.11.5.87 (2021)”).

To achieve this, we could define the following in the ModuleSettings object, assuming that the FieldDescriptorIDs have already been defined elsewhere in the script/code:

```csharp
var settings = new ModuleSettings()
{
    ModuleId = "moduleid",
    DomManagerSettings = new DomManagerSettings()
    {
        DomInstanceNameDefinition = new DomInstanceNameDefinition()
        {
            ConcatenationItems = new List<IDomInstanceConcatenationItem>()
            {
                new FieldValueConcatenationItem(switchBrandDescriptorId),
                new StaticValueConcatenationItem(" "),
                new FieldValueConcatenationItem(switchModelDescriptorId),
                new StaticValueConcatenationItem(" - "),
                new FieldValueConcatenationItem(managementIpDescriptorId),
                new StaticValueConcatenationItem(" ("),
                new FieldValueConcatenationItem(yearDescriptorId),
                new StaticValueConcatenationItem(")")
            }
        }
    }
};
```

> [!NOTE]
>
> - When no concatenation is defined (i.e. when DomInstanceNameDefinition is empty or null), the ID of the DomInstance will be used as DomInstance name.
> - When multiple values are defined for the same FieldDescriptor (i.e. when there are multiple Sections for the same SectionDefinition), the first value will be used for the concatenation.
> - The DomInstanceNameDefinition can be overridden by a DomDefinition on the ModuleSettingsOverrides property.

#### DataMiner Object Model: SectionDefinitionId, DomDefinitionId, DomInstanceId and DomTemplateId objects now all have a ModuleId property \[ID_30302\]

The SectionDefinitionId, DomDefinitionId, DomInstanceId and DomTemplateId objects will now all have a ModuleId property. This property will automatically be filled in when a SectionDefinition, DomDefinition, DomInstance or DomTemplate object is added or updated.

> [!NOTE]
>
> - SectionDefinitions linked to the JobManager will have their ModuleId set to null.
> - Existing objects will only have their ModuleId property filled in the first time they are updated.

#### Cassandra: Alarm squashing setting will by default be set to false when it cannot be requested from SLNet \[ID_30309\]

From now on, when it is not possible to request the value of the alarm squashing setting from SLNet when retrieving alarms from a Cassandra database, by default the alarm squashing setting will be considered false.

#### Connecting a DataMiner System to the Cloud \[ID_30513\]

It is now possible to connect a DataMiner System to the cloud. However, note that the Live Sharing feature, which relies on this cloud connection, is currently only available in soft launch.

To connect your DMS to the cloud:

1. Verify that each DMA that will be connected to the cloud is able to reach the following endpoints:

    - `https://connect.dataminer.services/`
    - `wss://tunnel.dataminer.services/`

2. Download the appropriate DataMiner Cloud Pack installer from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is required to connect the DataMiner Cloud, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

3. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following user permissions.

    - *System configuration* > *Cloud gateway* > *Connect to DCP*
    - *System configuration* > *Cloud gateway* > *Disconnect from DCP*

4. Click the *Register* button. A pop-up browser window will open.

    > [!NOTE]
    > Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

5. Specify the following information in the pop-up window:

    - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system, or by clicking *Create new* and specifying your name and DNS.
    - DMS name: Specify the name you want to use for your DMS.
    - DMS URL: Specify a URL-friendly version of the DMS name.

6. Select the checkbox to agree to the terms of service and click *Connect*.

7. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Registered*. This can take up to half a minute.

If your DMS was already connected to the cloud using the earlier soft-launch version of this feature, install the DataMiner Cloud Pack installer on at least one DMA that was already hosting the cloud gateway, as described in step 2 above.

> [!NOTE]
> Make sure that all users that should be able to share data with the cloud have the following user permissions:
>
> - *System configuration* > *Cloud sharing* > *Share item*
> - *System configuration* > *Cloud sharing* > *Account linking*

### DMS Security

#### Automatic LDAP notifications disabled by default \[ID_30290\]

Up to now, when Active Directory was used, DataMiner would automatically receive updates whenever changes occurred in the domain. From now on, this feature will be disabled by default. Instead, DataMiner will now poll the LDAP system on an hourly basis to check for changes.

> [!NOTE]
> If you want to enable the automatic LDAP notification feature, open the DataMiner.xml file and set the LDAP notifications attribute to true.

### DMS Protocols

#### View table columns with options like 'view=:x:y:z' or 'view=a:b:c:z' can now be filtered by means of a 'VALUE=' filter \[ID_30237\]

View tables containing a column with view options like “view=:x:y:z” or “view=a:b:c:z” now allow that column to be filtered by means of a “VALUE=” filter (e.g. VALUE=5 == abc).

> [!NOTE]
> Combining filters with AND or OR is not supported.

### DMS Cube

#### Spectrum recording playback: Play modes 'Play once' and 'Loop' replaced by 'Keep repeating the recording' checkbox \[ID_30218\]

Up to now, while a spectrum trace recording was playing, you could select the play modes *Play once* or *Loop*. Those play modes have now been replaced by the *Keep repeating the recording* checkbox.

#### DataMiner Cube start window: Cleanup Cube Installation window \[ID_30351\]

When you click the cogwheel icon in the bottom-right corner of the DataMiner Cube start window, you can now select the *Cleanup* option to open the *Cleanup Cube Installation* window. That window will allow you to remove old and/or unused Cube versions as well as to clear the Visio cache and the protocol cache.

#### Alarm templates: Baseline editor now allows you to configure baselines and smart baselines specified in protocols \[ID_30388\] \[ID_30461\]

Up to now, when a parameter had a (smart) baseline value specified in the protocol, it was not possible to update that (smart) baseline value in Cube’s alarm template baseline editor. From now on, that editor will allow you to configure (smart) baselines specified in protocols.

> [!NOTE]
>
> - The alarm template baseline editor will not allow you to change the monitoring type (Normal, Relative, Absolute or Rate).
> - When a baseline is specified in a protocol, the baseline value is stored in a separate parameter. Although you should specify a read parameter (e.g. `<Alarm type="absolute:READ_PARAM_ID,108">`), make sure that read parameter has an associated write parameter. Otherwise, it will not be possible to update the baseline value stored in that parameter. Also, the parameter in which the baseline value is stored must be free of any restrictions (e.g. step size, number of decimals, high/low range, etc.)

#### Data Display: Extended support for launching elements, services, redundancy groups and views by clicking buttons in Data Display table cells \[ID_30413\]

This feature offers a new way of adding links to elements, services, redundancy groups or views in a Data Display table.

When, in a protocol, you configure a cell button as shown below, the table cell will display an icon that includes the severity and, if necessary, the name. Clicking the link will open the linked object in a new card.

Example:

```xml
<Measurement>
  <Type>button</Type>
  <Discreets>
    <Discreet>
      <Display>{linkedItemName}</Display>
      <Value type="open">{pid:530}</Value>
    </Discreet>
  </Discreets>
</Measurement>
```

The discreet value can contain the name or the ID of the object, or a reference like “{pid:530}”. In the example above, the identifier is stored in the column with parameter ID 530, which can be the read parameter of the same column or a different column.

If you know the type of the object, you can add a type prefix (element, redundancygroup, view or service), followed by an equal sign and (a reference to) the identifier. If you refer to the name of the object, it is recommended to use “element=” as an element can have the same name as a view.

The \<Display> tag of the discreet can contain the same references as the \<Value> tag. One extra keyword is possible (and recommended): {linkedItemName}. This keyword will be replaced with the name of the object referred to in the \<Value> tag.

If you want to specify the page to be selected by default, add a suffix to the identifier in the \<Value> tag containing the root page name and the page name, separated by a colon. See the following examples:

- element=MyElementName:Data:Performance
- 212/13:Visual:MyVisioPage

#### New /Bootstrap command line argument for DataMiner Cube launcher \[ID_30573\]

A new */Bootstrap* command line argument is now supported for the DataMiner Cube launcher. This argument combines the */Install* and */Silent* arguments (see [Desktop application command-line arguments](xref:Desktop_app_command_line_arguments)), and also copies a number of files, such as *DataMinerCube.exe.config* en *CubeLauncherConfig.json*.

### DMS Reports & Dashboards

#### Dashboards app - GQI: New 'Get alarms' data source \[ID_30320\] \[ID_30420\]

In the Generic Query Interface, a new “Get alarms” data source is now available. It will return all alarms in the DMS.

The following columns will be returned by default:

- Element name
- Parameter description
- Value
- Time
- Root time
- Severity
- Service impact
- RCA level
- Alarm type
- Owner

The following columns can be added using a column selector node:

- Alarm description
- Alarm ID
- Category
- Component info
- Corrective action
- Comments
- Creation time
- Element ID
- Element type
- Hosting agent ID
- Interface impact
- Key point
- Offline impact
- Parameter ID
- Root creation time
- Root alarm ID
- Status
- Source
- Table index display key
- Table index primary key
- User status
- Virtual function impact
- View impact
- A column for every custom alarm property

#### Dashboards app - State component: 'Show units' option \[ID_30322\]

In the *Settings* tab of a *State* component, it is now possible to select or clear the *Show units* option to show or hide the unit of the parameter.

#### Dashboards app - GQI: Queries verified and repaired when opened for editing \[ID_30507\]

When, in the Dashboards app, you open a GQI query to edit it, it will now first be verified and repaired if necessary. Only when verification and repair have finished will you be able to edit the query.

#### Dashboards app - chart components: Loading indicator \[ID_30515\]

When you opened or refreshed a dashboard, up to now, the chart components on that dashboard would show “no data” until the data had been fully loaded. From now on, when data is being loaded into a state component or a chart component using data from a query, a loading indicator will be shown instead.

### DMS Maps

#### Filtering on alarm severity: \<Checkbox> tags now have a 'checked' attribute \[ID_30429\]

If you want a map to contain a filter box that allows users to filter map items based on their alarm severity level, then you add a \<FilterBox> tag that contains a checkbox for every alarm severity level. From now on, it is possible to indicate whether those checkboxes should be selected or cleared by default. To do so, add a “checked” attribute to each of the checkboxes, and set their value to either true or false.

See the following example:

```xml
<MapConfig ...>
  ...
  <FilterBox visible="true">
    <CheckBoxes>
      <CheckBox alarmLevel="Normal" name="connected" checked="true" />
      <CheckBox alarmLevel="Critical" name="not connected" checked="true" />
      <CheckBox alarmLevel="Undefined" name="unknown" checked="false" />
    </CheckBoxes>
  </FilterBox>
  ...
</MapConfig>
```

> [!NOTE]
> If, for a particular checkbox, you do not specify a “checked” attribute, then the checkbox will be selected by default.

### DMS Web Services

#### Web Services API v1: CreateElement and EditElement methods now allow to create and edit replicated elements \[ID_30339\]

The CreateElement and EditElement methods now allow you to create and edit elements that replicate elements from a different DataMiner System.

In the configuration section, you will find a ReplicationInfo subsection that allows you to specify the necessary settings.

#### Web Services API v1: New methods to manage alarm templates \[ID_30383\]

The following new methods now allow you to create, update, delete and assign alarm templates:

- CreateAlarmTemplate
- UpdateAlarmTemplate
- DeleteAlarmTemplate
- AssignAlarmTemplate

### DMS web apps

#### Web app tooltips: Increased contrast to enhance readability \[ID_30283\]

In all web apps, tooltip contrast has been increased to enhance readability.

#### Web app tooltips: Cursor now changes from arrow to hand when hovering over a tooltip of an input component \[ID_30285\]

From now on, when you hover the mouse pointer over a tooltip of an input component, the arrow will change into a hand.

### DMS Service & Resource Management

#### Profile Manager: Enhanced performance when executing bulk create/update operations against an Elasticsearch database \[ID_30152\]

Due to a number of enhancements to the AddOrUpdateBulk calls of the ProfilesHelper and ProfileManagerHelper, overall performance has increased when creating or updating ProfileParameters, ProfileInstances and ProfileDefinitions in bulk in an Elasticsearch database.

#### Service & Resource Management: No longer possible to create a resource with invalid capacities and/or capabilities \[ID_30207\]

From now on, it will no longer be possible to add a resource with invalid capacities and/or capabilities.

- When you try to add a resource with “NULL” instead of a Capacity or with a Capacity of which the value is set to “NULL”, an error with reason ResourceCapacityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapacity: The capacity object that did not reference a correct capacity profile.

- When you try to add a resource with “NULL” instead of a Capability or with a Capability of which the value is set to “NULL” and IsTimeDynamic set to FALSE, an error with reason ResourceCapabilityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapability: The capability object that did not reference a correct capability profile.

#### Automation - Service & Resource Management: New ServiceResourceUsageDefinition.Role property \[ID_30214\]

A *ServiceResourceUsageDefinition* object now has an extra *Role* property, with the following possible values: *Mapped* (default value), *Unmapped* and *Inheritance*. This property is intended to be used by the Booking Manager app, where it will determine whether a resource is mapped to a node of a service definition.

#### ReservationInstance behavior enhancements \[ID_30295\]

ReservationInstance behavior has been changed in the following ways:

- ReservationInstances that have a start time before the time the ResourceManager was initialized will no longer automatically have their status set to “Interrupted”. Only instances that were unable to start because the ResourceManager was not yet initialized will have their status set to “Interrupted”.
- All ReservationEvents that have not yet run will be scheduled if the ReservationInstance does not have its status set to “Interrupted”. In other words, all missed events will be run immediately when you add a ReservationInstance with a start time.

#### ResourceManagerEventMessage will now be sent when a ReservationInstance property was updated \[ID_30352\]

From now on, a ResourceManagerEventMessage will be sent next to the existing ReservationInstanceChangePropertiesEventMessage when a ReservationInstance property was updated using either ResourceManagerHelper#UpdateProperties or ResourceManagerHelper#SafelyUpdateProperties.

#### Additional availability check for contributing resources \[ID_30498\]

The GetEligibleResources and AddOrUpdateReservationInstances calls determine the availability of a contributing resource during a certain time range based on a number of criteria. Now, an extra criterion has been added:

- If the contributing booking linked to the resource has LockLifeCycle set to “Locked” and the main booking has a start time in the past but an end time in the future, then the contributing resource will be considered available if the time range of the contributing booking only overlaps the future part of the time range of the main booking.

## Changes

### Enhancements

#### Security enhancements \[ID_30200\] \[ID_30323\] \[ID_30362\] \[ID_30363\] \[ID_30417\] \[ID_30422\] \[ID_30423\] \[ID_30494\] \[ID_30561\]

A number of security enhancements have been made.

#### DataMiner Cube - Trending: Enhanced input and validation of trend graph Y axis settings \[ID_30176\]

When you right-click on a trend graph and select “Y axis settings”, you can change the minimum and maximum Y-axis value for each numeric axis. A number of enhancements have now been made with regard to how these values are entered and validated.

#### Service & Resource Management: Enhanced performance when creating bookings \[ID_30209\]

Due to a number of enhancements, overall performance has increased when creating bookings, especially in situations with a large number of overlapping bookings that use a large number of resources.

#### Enhanced performance when creating function resources \[ID_30248\]

Due to a number of enhancements, overall performance has increased when creating function resources.

#### SLElement: Enhanced performance when processing table request filters \[ID_30262\]

Due to a number of enhancements, overall performance of SLElement has increased when processing table request filters.

#### SLElement: Enhanced performance when managing virtual elements \[ID_30274\]

Due to a number of enhancements with regard to the caching of key links, overall performance of the SLElement process has increased when managing virtual elements.

#### Service & Resource Management: Enhanced performance when adding and updating function resources \[ID_30280\]

Due to a number of enhancements, overall performance has increased when adding and updating function resources, especially when adding a large number of resources on the same parent element.

#### Enhanced performance when including/excluding elements in services based on parameter values \[ID_30284\]

Due to a number of enhancements, overall performance has increased when including/excluding elements in/from services based on parameter values, especially when the same parameter is used in a large number of element inclusion conditions.

#### Tools page now allows you to install SECTIGO certificate \[ID_30297\]

DataMiner Cube files are now signed with a SECTIGO certificate.

You can install that certificate by clicking a hyperlink in the *DataMiner tools* section of the `http://[dma]/root/tools/` page.

#### SLElement: Enhanced performance when starting up elements \[ID_30315\] \[ID_30316\]

Due to a number of enhancements, overall performance of SLElement has increased when starting up elements, especially DVE elements and elements with a large number of foreign keys, virtual functions, etc.

#### Enhanced performance due to improved locking mechanism \[ID_30328\]

Due to a number of enhancements to the internal locking mechanism, overall performance of all DataMiner processes has increased.

#### SLElement: Enhanced performance when resolving foreign keys \[ID_30348\] \[ID_30426\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving foreign keys, especially when dealing with replicated elements.

#### DataMiner Cube - Bookings app: Enhancements made to bookings timeline and bookings list \[ID_30354\]

Up to now, whenever the “now” line re-appeared in the visible range of the bookings timeline, the Follow mode would automatically be enabled again. From now on, the Follow mode will instead get the status it had before the “now” line last disappeared from the visible range.

Also, when you change the time range in the booking timeline, the bookings list will now be refreshed instead of reset. In other words, the list will no longer be cleared and rebuilt before the list filter is re-evaluated.

#### SLNet will now notify SLWatchdog when it has updated VersionHistory.txt \[ID_30366\]

When the SLWatchdog process is started, it checks the VersionHistory.txt file to find out the DataMiner version running on the DataMiner Agent in question. The VersionHistory.txt file, located in the C:\\Skyline DataMiner\\Upgrades\\ folder of a DataMiner Agent, lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Up to now, when SLNet updated the DataMiner version in VersionHistory.txt while SLWatchdog was running, the latter would not be aware of that change until it was restarted. From now on, SLNet will notify SLWatchdog when it has updated VersionHistory.txt.

#### DataMiner Cube: Links to deprecated DCP platform replaced by links to the new dataminer.services platform \[ID_30430\]

Throughout the Cube UI, all links to the deprecated DataMiner Collaboration Platform have been replaced by links to the new <https://dataminer.services> platform.

#### DataMiner Cube - Data Display: Memory consumption of tables showing service impact has been reduced \[ID_30433\]

Due to a number of enhancements, overall memory consumption of tables showing service impact has been reduced.

#### SLElement: Enhanced performance when processing updates in tables with foreign key columns \[ID_30434\]

Due to a number of enhancements, overall performance of SLElement has increased when processing updates in tables with foreign key columns.

#### DataMiner upgrade packages will now include StandAloneBpaExecutor \[ID_30438\]

The StandAloneBpaExecutor tool will now by default be included in DataMiner upgrade packages.

#### Enhanced performance of SLNet when managing DVE elements on systems with an offload database \[ID_30439\]

Due to a number of enhancements, overall performance of SLNet has increased when managing DVE elements on systems with an offload database.

#### DVE elements and virtual functions will start faster when their main element is restarted \[ID_30457\]

Due to a number of enhancements, DVE elements and virtual functions will start faster when their main element is restarted.

#### Enhanced performance when stopping elements that are in a timeout state \[ID_30462\]

Due to a number of enhancements, overall performance has increased when stopping elements that are in a timeout state.

### Fixes

#### Problems when initializing scheduled alarm templates \[ID_29783\] \[ID_30365\]

In some cases, an alarm template group that was either unassigned or assigned to a stopped element would not get updated when the schedule of one of the alarm templates in that group was enabled or disabled.

Also, when an alarm template schedule was started, in some cases, either the active state of that schedule or the entire schedule itself would be set incorrectly.

- When an alarm template with a schedule was edited while, according to its schedule, it was inactive, the following would happen:

  - The template would temporarily be activated, causing alarms to be created which would immediately be cleared.
  - When no active window was scheduled that day, the first window of the upcoming days would be used for that day.

- When an alarm template with a schedule was assigned to an element while, according to its schedule, it was inactive, it would be activated until the first window had passed.

- When an alarm template schedule contained an overlapping window because DataMiner Cube did not detect the incorrect configuration, the overlap would not get corrected and the schedule would get activated at random times.

- When an alarm template with a schedule was updated on a DMA that was part of a DataMiner System, elements running on other DMAs in that DataMiner System would not apply the new schedule until the DMA on which the template was updated was restarted or until another alarm template update occurred on that DMA.

NT_ADD_FILE (99) has now been adapted in order to better handle alarm template changes. When NT_ADD_FILE is called and the templateDetails variable (object 2) specifies the type as “1” (alarm template), then the protocolDetails variable (object 1) will optionally receive a fourth string value: “364” (NT_INITIALIZE_SCHEDULE) or “378” (NT_CLEAR_SCHEDULE). This will specifies how the template's schedule should be reloaded in the memory of SLDataMiner.

> [!NOTE]
> When no fourth string value is passed along, it will by default be set to NT_INITIALIZE_SCHEDULE as it is capable of handling a template without a schedule.

#### Jobs app: Current job domain would incorrectly be refreshed when navigating from configuration to jobs overview \[ID_30081\]

When you navigated from the configuration pane to the jobs overview, in some cases, the current job domain would incorrectly be refreshed.

#### DataMiner Cube - Alarm templates: Hysteresis could incorrectly be applied to 'low' severity levels for parameters of type string \[ID_30117\]

When applying hysteresis to specific alarm severity level for parameters of type string, up to now, it would incorrectly be possible to do so for “low” severity levels. From now on, for parameters of type string, it will only be possible to apply hysteresis to “high” severity levels.

> [!NOTE]
> If, for a string parameter, Hysteresis is set to “On” or “Off”, then the High and Low levels must be consistent. Both should either be enabled or disabled.

#### DataMiner Cube - Scheduler: Tasks with a type other than 'Once' would incorrectly allow you to enter a date and a time in the start date box \[ID_30140\]

When you configure a scheduled task with a type other than “Once”, you can specify a start date and an end date. Up to now, the start date box would allow you to enter a date and a time. As this is not relevant, from now on, the start date box will only allow you to enter a date.

#### DataMiner Cube - Visual Overview: Problem with session variables that control an embedded Resource Manager component \[ID_30180\]

When a Resource Manager component is embedded in a visual overview, it can be controlled by a number of session variables. For example, with YAxisResources you can set the timeline bands and with SelectedReservation you can highlight a certain booking.

Normally, the bands must be updated before a new selection is set. However, in some cases, the selection was set first, both session variables were set simultaneously, or the time line band was set via an Execute page option. From now on, when timeline bands are updated, the latest “set booking selection” will be always be set again to make sure the selection is kept even when bands are changed or updated.

#### Problem with SLElement when the hysteresis timer was activated when an element was restarted \[ID_30212\]

In some rare cases, an error could occur in SLElement when the hysteresis timer was activated at the moment when an element was restarted.

#### SLDataGateway: 'Connection was closed' error \[ID_30213\]

In some cases, a “connection was closed” error could occur in the SLDataGateway process.

#### SLAnalytics: Problem when the connection with SLNet was lost \[ID_30238\]

In some rare cases, an error could occur in SLAnalytics when the connection with SLNet was lost.

#### CPU usage of SLASPConnection would surge after a service update \[ID_30242\]

On systems with a large number of services, in some cases, the CPU usage of the SLASPConnection process would temporarily surge after a service had been updated.

#### DataMiner Cube - Surveyor: Newly created element would be displayed twice after being updated \[ID_30258\]

When a newly created element was in multiple views, and at least two of these views had been opened in the Surveyor, in some cases, the element would incorrectly be displayed twice in the same view after being updated.

#### DataMiner Cube could become unresponsive when the Bookings app was closed \[ID_30261\]

In some cases, DataMiner Cube could become unresponsive when you closed the Bookings app.

#### DataMiner Cube - Visual Overview: Problem when the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured \[ID_30270\]

In some rare cases, an exception could occur when, in a visual overview, the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured.

#### Problem with SLElement when changing an alarm template of a DVE element that contained references to general parameters in conditional monitoring rules \[ID_30277\]

When a DVE element had its alarm template updated, was assigned a new alarm template or went to “not monitored”, in some cases, an access violation error could occur in SLElement when the alarm template contained references to general parameters in conditional monitoring rules.

#### DataMiner Cube - Services app: Same connection could incorrectly be drawn twice in diagram \[ID_30291\]

When drawing connections between nodes in a service definition diagram, in some cases, it would incorrectly be possible to draw the same connection twice.

#### Web apps: Problems with DefaultTimeZone setting \[ID_30301\]

The time displayed in the DataMiner web apps (e.g. Jobs, Dashboards, etc.) is based on the DefaultTimeZone setting in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file.

Up to now, the following problems could occur with regard to this setting:

- When DefaultTimeZone was set to a time zone without offset (e.g. UTC), in some cases, an error message could appear.
- In the Dashboards app and the Monitoring app, the configured time zone would not always be applied correctly.

#### Cassandra cluster: Problems with cluster health monitoring & data offloads \[ID_30310\]

In some cases, an incorrect consistency level and replication factor would be used when assessing the health of the Cassandra cluster.

Also, a problem could occur when offloading data to a file.

#### DataMiner Cube - Alarm Console: Sources of correlated alarms would incorrectly not be removed from the Alarm Console \[ID_30311\]

In some rare cases, the sources of a correlated alarm would incorrectly not be removed from the Alarm Console.

#### BPA tests: Version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version \[ID_30312\]

A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any). However, up to now, the version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version.

The version compatibility test has now been adapted:

- When no minimum and/or maximum DataMiner version is specified, the BPA test will run regardless of the version.
- When a minimum and/or maximum DataMiner version is specified, the BPA test will run when the DataMiner Agent has

  - a Main Release version greater than the minimum Main Release version and smaller than or equal to the maximum Main Release version, or
  - a Feature Release version greater than the minimum Feature Release version and smaller than or equal to the maximum Feature Release version, or
  - a Release version of which the Main Release on which it is based is greater than the minimum Feature Release version and smaller or equal to the maximum Feature Release version.

#### SLNet would fail to initialize when external authentication via SAML was configured incorrectly \[ID_30318\]

When external authentication via SAML was configured incorrectly, up to now, SLNet would fail to initialize. From now on, a “Failed to build External Authentication for SAML” notice will be generated instead and SLNet will continue its initialization routine.

#### SLAnalytics: 'Division by zero' error when encountering an invalid polling time in legacy parameterInfo records \[ID_30321\]

In some cases, a “division by zero” error could occur in SLAnalytics when encountering an invalid polling time in legacy parameterInfo records.

#### Read/write operations on alarm and information event records would incorrectly be executed against Elasticsearch even when “Enable indexing on alarms” was disabled \[ID_30330\]

On systems with an Elasticsearch database, read/write operations on alarm and information event records would incorrectly be executed against the Elasticsearch database even when the “Enable indexing on alarms” setting was disabled.

#### DataMiner Cube - Alarm Console: Submenu of Copy command not shown in right-click menu \[ID_30334\]

When, in the Alarm Console, you selected all alarms with element name “DMA” and then right-clicked to open the shortcut menu, the submenu of the “Copy” command would incorrectly not be shown.

#### DVE elements / Virtual functions: Alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed \[ID_30336\]

In some cases, alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed.

#### SLAnalytics - Automatic Incident Tracking: Times of arrival of all alarm groups would incorrectly be updated when the polling IP address of an element or a custom property was changed \[ID_30342\]

When the polling IP address of an element or a custom property of a view, service or element was updated, the times of arrival of all alarm groups would incorrectly be updated internally. From now on, only the times of arrival of the alarm groups affected by the change will be updated.

#### Dashboards app: 'Loading' bar would stay visible longer than necessary \[ID_30343\]

In some cases, the “Loading” bar, which is visible while the Dashboards app is busy loading all components, would stay visible longer than necessary. From now on, it will disappear immediately after all components have been loaded.

#### Dashboards app - GQI: Query builder would keep on rebuilding a query when feeds were linked to it \[ID_30347\]

In some cases, the query builder would keep on rebuilding a query when feeds were linked to it.

#### Problem with SLDataMiner \[ID_30359\]

In some cases, the SLDataMiner process could become unresponsive due to a problem with its element locking mechanism.

#### Enabling or disabling a Failover setup would break the Cassandra cluster \[ID_30361\]

When either enabling or disabling a Failover setup using a Cassandra cluster, in some cases, the Cassandra cluster would break.

#### Failover: 'DB forwarding is failing' alarm would incorrectly be generated when using Cassandra Cluster \[ID_30392\]

In a Failover environment using a Cassandra Cluster, in some cases, the following alarm would incorrectly be generated:

```txt
Failover DB forwarding is failing since YYYY-MM-DD HH:MM:SS
```

#### DataMiner Cube - Visual Overview: Service definition passed in a session variable to an embedded Service Manager component would not be selected in that component \[ID_30396\]

When a service definition was passed in a session variable to an embedded Service Manager component, in some cases, that service definition would not be selected and, as a result, its diagram would not be loaded.

#### Interactive Automation scripts: Lazy-loaded tree controls would incorrectly not forward their selected items \[ID_30406\]

When a dialog contained multiple lazy-loaded tree controls, in some cases, those controls would not forward their selected items.

#### EPM: All clients would incorrectly receive view updates when one view was enhanced \[ID_30412\]

When, in an EPM environment, you enhanced a view on a particular DataMiner Agent in the DMS, all clients connected to any of the other DataMiner Agents in the DMS would incorrectly receive updates for all of the enhanced views in the system.

#### Legacy Reports & Dashboards - Alarm List: History alarms with missing ‘Hosting DataMiner ID’ & GetAlarmTreeDetailsMessage not working for imported elements \[ID_30415\]

When, in the legacy Reports & Dashboards app, the Alarm List component requested the alarm tree details, all history alarms would incorrectly have a hosting DataMiner ID equal to -1 and using the GetAlarmTreeDetailsMessage with Hosting DataMiner ID and Root Alarm ID did not work for elements imported by means of a DELT package.

#### Failover: SLASPConnection would be unaware of the local DMA ID \[ID_30416\]

On a Failover setup, part of the SLASPConnection process would be unaware of the local DataMiner ID. In some cases, this could lead to “Handle Notifications Thread” errors.

#### Security: Problems when adding domain users and domain groups \[ID_30428\]

In some cases, a problem could occur when adding a domain user or a domain group to DataMiner.

#### Dashboards app - GQI: Queries could cease to function when items used in those queries were renamed \[ID_30436\]

Up to now, in some cases, a GQI query could cease to function when items used in that query (e.g. parameters, profile definitions, etc.) were renamed.

#### Dashboards app - State timeline: Problem with state change highlighting in Mozilla Firefox \[ID_30446\]

When using the Dashboards app in Mozilla Firefox, the state timeline component would not highlight the correct state change when you hovered over the component.

#### Memory leak in SLNet after SLDataGateway failed to retrieve the status of a database operation \[ID_30450\]

In some cases, the SLNet process could start leaking memory after SLDataGateway failed to retrieve the status of a database operation.

#### DataMiner Cube: Problem when opening a service \[ID_30471\]

In DataMiner Cube, in some cases, a stack overflow exception could be thrown when you opened a service.

#### Failover: Redirection problem when using a shared hostname \[ID_30473\]

On Failover systems using a shared hostname instead of a shared virtual IP address, in some cases, users connecting to the offline agent would not be redirected properly to the online agent.

#### Service & Resource Management: Start actions and events of a canceled booking would incorrectly still be triggered \[ID_30477\]

When the status of an existing booking was set to “Canceled”, in some cases, the associated start actions and events would incorrectly still be triggered.

#### Ticketing app: Problem with drop-down fields \[ID_29478\]

When you added or updated options in a field of type “drop-down list”, in some cases, the default values of those options were not filled in correctly.

Also, when you turned a field into a field of type “drop-down list”, in some cases, a null reference exception could be thrown.

#### Dashboards app - State timeline: Unclear error message when no parameter index has been specified yet \[ID_30485\]

When you dragged a table parameter onto a state timeline component, up to now, the following error would be visible until you specified a table index:

```txt
Failed getting the timeline data from the DMA agent: Empty server response
```

This error will now be replaced by a message that clearly indicates that the table index is still missing and should be specified.

#### Dashboards app - Tree feed & Parameter feed: Problem with 'Selected only' option \[ID_30510\]

When you open a dashboard containing a tree feed or a parameter feed with a preset selection in the URL, the “Selected only” option of those feeds is selected by default.

Up to now, when you cleared that option in one of those feeds and then selected other items in the feed, the “Selected only” option would incorrectly be selected again.

#### Incorrect exceptions thrown when installing a DataMiner upgrade package \[ID_30516\]

When you install a DataMiner upgrade package, a number of checks are performed before the upgrade is started. In some cases, one of those checks would throw incorrect ZipExceptions.

#### Dashboards app - Parameter feed: Indices of selected items would not all be selected \[ID_30532\]

When you opened a dashboard containing a parameter feed with a preset selection, in some cases, the indices of the selected items would not all be selected.

#### DataMiner Cube - Visual Overview: Asterisk in shape text of an 'Info' shape would not be replaced when the shape text contained more than just the asterisk \[ID_30534\]

When the shape text of an “Info” shape contained more than just an asterisk (“\*”), in some cases, the asterisk would not be replaced with the information specified in the Info shape data field.

#### DataMiner Cube - System Center: Clicking 'Failover...' would incorrectly show the Failover configuration of the DMA to which you were connected \[ID_30535\]

When, in the *Agents* section of *System Center*, you selected a DataMiner Agent and clicked *Failover* to check its Failover configuration, the *Failover Config* window would incorrectly always show the Failover configuration of the DataMiner Agent to which you were connected.

#### DataMiner Cube - Tab layout: Clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question \[ID_30541\]

When in tab layout, clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question.

> [!NOTE]
> When, on a visual overview, you click a button to navigate to another card and then click the *Back* button, in some cases, clicking the button to navigate to another card a second time may no longer open that other card.

#### Legacy Reporter app - Bookings component: Not possible to select properties \[ID_30547\]

When, in the legacy Reporter app, you had created a report template with a booking component of which the type was set to “list”, in some cases, it would not be possible to select properties to be included in the report.

#### DataMiner Cube - Data Display: Table cells would not contain their current value when in edit mode \[ID_30553\]

In some cases, when you had changed a value in a table cell, and then clicked inside that same cell to change the value again, the cell would not contain the current value. Instead, it would contain the value it contained before the first change.

#### Dashboards app - GQI: Not possible to create new GQI queries on DataMiner systems without an Elasticsearch database \[ID_30578\]

In some cases, it would no longer be possible to create new GQI queries on DataMiner systems without an Elasticsearch database.

#### Visual Overview: Delay when setting variable \[ID_30595\]

When a variable was set in Visual Overview, it could occur that there was a delay of 1 second. This could cause problems with an embedded Bookings component, e.g. when zooming in and out on the bookings timeline.

#### Problem when multiple threads simultaneously created the serializer when ServiceReservationInstances had to be serialized \[ID_30613\]

In some rare cases, a ProtoBufSerializationException could be thrown if multiple threads simultaneously created the serializer when ServiceReservationInstances had to be serialized using protocol buffer serialization.

#### DataMiner Cube - Service & Resource Management: Missing icons in service definitions \[ID_30619\]

In some cases, icons could be missing in service definitions because SVG content could not be loaded.

#### Resource Manager would fail to initialize during a DataMiner startup \[ID_30708\]

During a DataMiner startup, in some cases, the Resource Manager would fail to initialize.

#### DataMiner Cube - Visual Overview: Parameter with ID between 50,000 and 60,000 linked to a shape would incorrectly be interpreted as a spectrum parameter \[ID_30787\]

When you linked a parameter with an ID between 50,000 and 60,000 to a shape, that parameter would incorrectly be interpreted as a spectrum parameter. From now on, a parameter linked to a shape will only be interpreted as a spectrum parameter if the shape is also linked to a spectrum element.

#### Dashboards & Monitoring apps - Popups no longer working \[ID_30797\]

In the Dashboards app and the Monitoring app, in some cases, no popup would appear when you clicked a page button.
