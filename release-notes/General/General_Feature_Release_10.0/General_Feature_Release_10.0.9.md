---
uid: General_Feature_Release_10.0.9
---

# General Feature Release 10.0.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet

## New features

### DMS core functionality

#### DataMiner Application packages \[ID_25911\]\[ID_26027\]\[ID_26169\]\[ID_26243\]\[ID_26271\]\[ID_26338\]\[ID_26351\]\[ID_26371\]

From now on, it is possible to install a DataMiner application or solution on an existing DataMiner system by uploading and installing a so-called “application package”.

##### Creating an application package

To create an application package, create the following files and folders, and compress them into a zip file (e.g. AppPackage.zip):

AppInfo.xml

Scripts

- Install.xml
- Config.xml
- InstallDependencies

  - ...

- ConfigureDependencies

  - ...

AppInstallContent

- ...

| File/Folder | Contents |
|--|--|
| AppInfo.xml | General information about the application:<br> - Name<br> - Version<br> - Description<br> - Minimum DataMiner version<br> - Configuration parameters<br> - ... |
| Scripts | \-  Install.xml: a script containing all installation instructions<br> - Config.xml: a script that will be launched when the application or solution is configured or reconfigured<br> - InstallDependencies: a folder containing all DLL files used by the installation script<br> - ConfigureDependencies: a folder containing all DLL files used by the configuration script |
| AppInstallContents | All auxiliary files needed by the installation script. |

> [!NOTE]
>
> - The Install.xml script, which must be able to access all data stored in the AppInstallContents folder, should check whether the system contains an earlier version of the application or solution in question and upgrade it. A full installation from scratch is to be avoided.
> - All configuration parameters used by the Config.xml script can be specified in the AppInfo.xml file.

##### Structure of the AppInfo.xml file

```xml
<AppInfo>
  <Name>...</Name>
  <DisplayName>...</DisplayName>
  <Version>1.0.0</Version>
  <Description>...</Description>
  <LastModifiedAt>...</LastModifiedAt>
  <MinDmaVersion>...</MinDmaVersion>
  <AllowMultipleInstalledVersions>...</AllowMultipleInstalledVersions>
  <Configuration>
    <Entries>
      <Entry>
        <ID>...</ID>
        <Name>...</Name>
      </Entry>
      ...
    </Entries>
  </Configuration>
</AppInfo>
```

##### Script entry points

In both the Install.xml and Config.xml scripts, an entry point has to be defined.

- In the Install.xml script, define the following entry point:

    ```csharp
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
        public void Run(Engine engine, AppInstallContext context)
        {
            ...
        }
    }
    ```

    AppInstallContext has to contain the path to the extracted application package folder “AppInstallContents” as well as the version of the application package.

- In the Config.xml script, define the following entry point:

    ```csharp
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.ConfigureApp)]
        public void Run(Engine engine, AppConfigurationContext context)
        {
            ...
        }
    }
    ```

    AppConfigurationContext has to contain the configuration entry values.

##### Installing an application package

Application packages can be uploaded, viewed, installed and configured using the DataMiner SLNetClientTest tool. All commands related to application packages can be found under Advanced \> Apps \> AppPackages.

> [!NOTE]
> To be allowed to install application packages, you must be granted the following user permission:
>
> - Modules \> System configuration \> Agents \> Install App packages

Although the above-mentioned method is to be preferred, it is also possible to embed an application package into a .dmupgrade package. To install an application package this way, do the following:

1. Create a .dmupgrade package.

2. In the UpdateContent.txt file of that package, add an “InstallApp” instruction, followed by the path to the application package you created earlier:

    ```txt
    InstallApp ./Path/To/AppPackage/AppPackage.zip
    ```

3. Install the .dmupgrade package on a DataMiner Agent that is running.

    > [!NOTE]
    >
    > - Make sure the .dmupgrade package does not contain any instructions to stop the DataMiner Agent.
    > - If you intend to install the .dmupgrade package using the DataMiner Taskbar Utility, make sure the DataMiner Agent is running.
    > - If you install the .dmupgrade package onto a DataMiner System, the DataMiner Agent on which the upgrade is launched will run the installation script found in the application package. If the upgrade is launched from a DataMiner Agent that is not a member of the DataMiner System, then the DataMiner Agent with the first IP address (in alphabetical order) will run the installation script.
    > - It is not possible to install an application package on multiple Agents of the same DataMiner System by adding their IP addresses to the “external IPs” list in DataMiner Cube. This would cause the installation script to be launched on each of the Agents in that list. If you want to install an application package on multiple Agents, you can select the Agents to be upgraded while connected to one of the Agents in the DataMiner System (which makes it unnecessary to have an external IPs list) or you can install it using the DataMiner Taskbar Utility.

##### AppPackageHelper

An AppPackageHelper class has been made available, containing a series of methods to manage application packages. The current methods include:

- UploadAppPackage
- GetUploadedAppPackages
- RemoveUploadedAppPackage
- InstallApp
- GetInstalledApps
- ConfigureInstalledApp
- GetCurrentAppConfiguration

#### LoggerUtil: RepositoryLoggerProvider & LogEntry API \[ID_26289\]\[ID_26291\]

The LoggerUtil tool now provides

- a RepositoryLoggerProvider that allows client applications to write log entries to an ElasticSearch database, and
- a LogEntry API that allows client applications to retrieve those entries.

A LogEntry object contains the following fields:

- Timestamp
- Message
- LogLevel
- Category (e.g. SRM.Reservations)
- Name (e.g. a specific booking ID)
- FullName (Category.Name)
- DmaId (ID of the DataMiner Agent to which the user was connected)
- ProcessId
- ProcessName
- ThreadId
- UserName

### DMS Security

#### DataMiner Cube - System Center: New user permissions \[ID_26437\]

In the Users/Groups section of Cube’s System Center, the following user permissions have been added:

- Service profiles (UI available, Edit definitions, Edit instances)
- BPA tests (Create/Update, Delete, Read, Execute, Get test results)

### DMS Cube

#### Visual Overview: Number groups in numeric parameter values displayed on element shapes will now be separated by a thin space / New DynamicUnits option \[ID_18321\]\[ID_26318\]\[ID_26330\]

In Visual Overview, three-digit number groups in numeric parameter values displayed on shapes with an *Element* and/or *Parameter* data field and a “\*” in the shape text will now by default be separated by a thin space. This will make large numbers more legible.

Also, a new *DynamicUnits* option will now allow you to enable the use of dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol. You may decide to enable this feature if you want to have large values converted to more legible values (e.g. to convert 1000 Mb to 1 Gb, 1000 m to 1 km, etc.).

To enable this feature, add an *Options* data field and set its value to “DynamicUnits=true”. By default, this option is disabled (i.e. false). See the following example:

| Shape data field | Value             |
|------------------|-------------------|
| Element          | MyElement         |
| Parameter        | 25                |
| Options          | DynamicUnits=true |

If you enable the *DynamicUnits* option, the following units will be converted out of the box:

- bytes (B)
- bits (b)
- bits per second (bps)
- bytes per second (Bps)
- Kibibytes (kiB)
- no unit (\<empty>)

If you want other units to be converted when you enable the *DynamicUnits* option, you can define this in the element protocol. See the example below.

Suppose you want to apply the following unit conversion rule:

- Display value in mm if value \< 1 cm.
- Display value in cm if value \> 1 cm.
- Display value in m if value \> 1 m.
- Display value in km if value \> 1 km.

Then, in the protocol, add the following configuration:

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit>cm</Unit>
    <Unit>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

#### Services app: Profile can now be referred to by value or by reference when configuring a service definition node \[ID_26118\]

When you configure a node in a service definition, a toggle button now allows you to specify whether the selected profile will be assigned by value or by reference.

#### Service & Resource Management - Visual Overview: Dynamically generating booking shapes \[ID_26154\]

It is now possible to automatically generate booking shapes. To implement this feature, do the following:

1. Create a shape representing the booking items, add a *ChildType* data field to that shape, and set its value to “Booking”.

2. Create a shape group containing the shape you made in step 1, add a *Children* data field to the shape group, and set its value to “Booking”.

By default, all bookings in the Cube cache will be shown. If that cache does not contain any bookings, then a default set of bookings will be retrieved (i.e. from 1 day in the past to 2 days in the future).

- If you want to set a specific time range, then add a *ChildrenSource* data field to the shape group and set its value to a specific time range (e.g. “StartTime=\<dateTime>; EndTime=\<dateTime>”).

    > [!NOTE]
    > If you retrieve a specific set of bookings by using a *ChildrenSource* data field set to a specific time range, the retrieved bookings will be added to the ones already present in the cache. If, by specifying a time range, you only want to filter the bookings currently in the cache, then use a *ChildrenFilter* data field instead.

- If you want to filter the bookings, then add a *ChildrenFilter* data field to the shape group and set its value to a booking filter, using the same filter format that is used when specifying a ListView filter.

- If you want to sort the bookings, then add a *ChildrenSort* data field to the shape group and set its value to “Name” (i.e. the default setting), “Property\|Start time” or “Property\|End time”, optionally followed by “,asc” (i.e. the default order) or “,desc”.

    > [!NOTE]
    > Dynamically generated booking shapes are functionally identical to shapes linked to bookings using a *Reservation* data field. For example, they support the same placeholders.

#### Visual Overview: New icons added to DataMiner stencils \[ID_26168\]

The following additional icons are now available in the DataMiner stencils:

- Element (A) DMX
- Element DMX
- Function (A) DMX
- Function DMX
- General Input
- General Output
- Redundancy Group (A) DMX
- Redundancy Group DMX
- Service (A) DMX
- Service DMX
- SLA (A) DMX
- SLA DMX
- View DMX

#### Visual Overview: New parameter control option 'ClientSidePollingInterval' \[ID_26223\]

When you have turned a shape into a table control that displays a direct view table, you can now use the *ClientSidePollingInterval* option to specify that this table should be refreshed at regular intervals.

| Shape data field        | Value                                                                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| ParameterControlOptions | ClientSidePollingInterval:\<interval><br> Example: To configure a polling interval of 1 minute, specify ClientSidePollingInterval:00:01:00. |

Minimum interval: 1 second

#### Visual Overview: HTML5 table controls can now have a filter box \[ID_26228\]\[ID_26235\]

Similar to Cube, visual overviews in HTML5 apps now also support table controls that include a filter box. In other words, when a parameter control shape with a table and a filter box defined in child shapes is passed to an HTML5 app, that shape will be rendered in the same way as it is rendered in Cube.

The child shapes (filter box and table) will have their coordinates defined relative to the parent shape.

- The filter box will contain an additional ExtraData item named VisualOverviewFilterBoxData with an optional CustomTextBoxInfo property.

- The table will contain an additional ExtraData item named VisualOverviewTableData.

If a table has been defined without a filter box, the parameter control will be passed to the HTML app without child regions.

#### Data Display: Number groups in numeric values will now be separated by a thin space \[ID_26251\]

In Data Display, three-digit number groups in numeric values will now by default be separated by a thin space. This will make large numbers more legible.

> [!NOTE]
> This so-called thousands separator will only be used to display numbers. Numbers that are copied, edited or exported will not contain any number group separators.

#### Cube Launcher: New tool to install a DataMiner Cube desktop application \[ID_26282\]\[ID_26381\]

From now on, you can use the Cube Launcher to install DataMiner Cube as a desktop applica-tion.

This new tool offers a number of advantages. It allows you to deploy multiple Cube versions side by side, and it will automatically select the correct Cube version when you connect to a DMA.

1. Browse to your DMA using a different browser than Internet Explorer.
1. Enter your username and password to log in.
1. Select *Desktop installation* and run the downloaded file.
1. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Windows.
1. Click *Install*.

   > [!NOTE]
   > Although it is still possible to install a DataMiner Cube desktop applica-tion using an MSI installation package, it is strongly advised to use the new Cube Launcher instead.

#### SNMP Managers: Polling IP address can now be added as a custom trap binding \[ID_26339\]

When configuring an SNMP manager, you can now add the polling IP address as a custom trap binding.

#### Profiles app: Display value configuration possible for capability profile parameters of type discrete \[ID_26379\]

Previously, when you configured a capability profile parameter of type discrete, it was not possible to specify display values for the raw values of the parameter. Now, with the *Discrete type* drop-down box, you can specify whether the display values are text or a number. Depending on this selection, the selection box for the discrete parameter will be either a text box or a spin box. When you specify the possible values for the parameter, there is now also an additional *Display value* column where you can specify the display value corresponding with each raw value. Both a raw value and a display value always need to be specified. The raw values always have to be unique, but this limitation does not apply for the display values.

Capability profile parameters of type discrete that were configured before this change will have no discrete type selected. For these parameters, the display value will remain equal to the raw value, unless they are reconfigured.

#### System Center: New 'Analytics config' system settings section \[ID_25124\]\[ID_26388\]

In *System Center*, the *System settings* section now contains a new *Analytics config* page, which allows you to configure a number of SLAnalytics settings.

#### Export: Selecting multiple items to be exported / New option to export data as displayed in view card \[ID_26450\]

From now on, it is possible to select multiple objects in a list and export them together in one file.

Also, when indicating which data to export, it is now possible to select the *Data as displayed in view card* option.

### DMS Reports & Dashboards

#### Dashboards app: Minimum and maximum values shown on line chart component \[ID_26063\]

When you hover the mouse pointer over a line chart component in the new Dashboards app, now the minimum and maximum values will be shown in addition to the average value that was already shown previously.

#### Dashboards app - Parameter feed: New option to automatically select a specified number of indices \[ID_26080\]

In the *Settings* tab of the parameter feed component, next to the *Auto-select all indices* option, there is now a new *Auto-select number of indices* option.

This new option will allow you to specify the number of indices that should be selected by default.

If the number of indices specified is greater than the number of indices that are being displayed, they will not be shown but selected in memory.

#### Dashboards app - Line chart component: New 'Hide parameters without trend data in the legend' option \[ID_26133\]

The line chart component has a new setting: Layout \> Styling and information \> Hide parameters without trend data in the legend.

When you enable this setting, the legend of the line chart component will no longer show items for which no trend data is available.

Default: enabled

#### Dashboards app - Parameter feed: Index filter separator \[ID_26136\]

The parameter feed component has a new (optional) setting: Index filter separator.

This setting allows you to specify the separator to be used when retrieving a filtered list of indices.

For example, if only the indices with a primary key equal to “X” have to be retrieved, and the index filter separator is set to “Y”, then the indices will be retrieved using the following filter: PK == X OR PK == \*YXY\*.

#### Dashboards app - Parameter page: New data/filter feed combinations \[ID_26143\]

The parameter page component can now be configured to use the following data feeds and filters:

| Data feeds                  | Possible data filter feeds                                                                                                                                                                                                                                       |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element                     | \-  Data page based on element (legacy option - if possible, use a data page based on protocol)<br> -  Data page based on protocol |
| Data page based on element  | \<No additional data filter feeds required>                                                                                                                                                                                                                      |
| Data page based on protocol | Element feed                                                                                                                                                                                                                                                     |

#### Dashboards app - Pivot table component: Enhancements \[ID_26316\]

A number of enhancements have been made to the pivot table component, including the following:

- Elements are now ordered by element name.
- When using mediation protocol parameters, the data will now be shown per mediation parameter.
- Server-side exceptions will now be handled more gracefully.

#### Dashboards app: Enhanced border configuration \[ID_26346\]

When configuring a dashboard theme or a component layout, up to now, it was only possible to specify whether borders had to be displayed or hidden. From now on, it is possible to specify on which of the four sides a border has to be displayed or hidden: top, right, bottom and/or left.

#### Dashboards app: New style layout options for State components displaying parameters \[ID_26454\]

In the Dashboards app, the layout options for the State component have been adjusted. If the component displays a parameter, the options that were previously available in the *Style* section are replaced with the following options:

- *Design*: Allows you to choose one of the following options:

  - *Small:* The component displays a single line containing a label and value.
  - *Large*: The component displays multiple lines with one value and up to three labels.
  - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

- *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

  - *LED*: The alarm color is displayed by a circular LED to the left of the first label.
  - *Line*: The alarm color is displayed by a bar along the left side of the component.
  - *Text*: The text color of the value matches the alarm color.
  - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.
  - *None*: No alarm color is displayed.

If the component displays a different DataMiner object, such as an element or service, the same options as before are available.

### DMS EPM

#### CPECollectorHelper API: Timeout parameters can now be configured in the SLNetClientTest tool \[ID_26247\]

When a call is performed via the CPECollectorHelper API, a timeout is calculated based on the amount of requested items using the following formula:

`Total Timeout = ((requested number of items / EPMBulkCount) + 1) * EPMASyncTimeout`

In the SLNetClientTest tool, it is now possible to configure the following parameters:

| Parameter       | Description                                                                                |
|-----------------|--------------------------------------------------------------------------------------------|
| EPMAsyncTimeout | The base value for a timeout when the CPECollector contacts another DataMiner Agent.       |
| EPMBulkCount    | The maximum number of items that can be requested in bulk before the timeout is increased. |

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

### DMS Web Services

#### BREAKING CHANGE - Web Services API v1: New and updated methods to manage job data \[ID_26006\]

In the Web Services API v1, the job management methods have all been modified to support job domains.

##### Changes to classes

The DMAJobDomain class, which now extends from the newly added DMAJobDomainLite class, contains a new SectionDefinitions property. That property will contain an array of DMASectionDefinitions that are linked to the JobDomain.

> [!NOTE]
>
> - Configuration has been marked obsolete. All client information will be available in the Info property of each SectionDefinition.
> - In DMASectionDefinitionInfo, the CustomSectionDefinitionExtensionID property has been marked obsolete.

##### Methods to manage job domains

- CreateJobsDomain(string connection, string name)

    Creates a job domain with a unique name, containing a default section definition. If the job domain was created successfully, the ID of the created job domain will be returned.

- GetJobsDomains(string connection)

    Retrieves all available job domains and sorts them naturally by name. Returns an array of JobDomainLite objects.

- GetJobsDomain(string connection, string domainID)

    Retrieves a job domain by ID. If no ID is provided, then the first domain found will be returned. Also, the method will migrate the client information in the user’s VisualData to JobDomain.VisualStructure.

- UpdateJobsDomain(string connection, string id, string name)

    Updates a job domain. If the job domain was updated successfully, the ID of the updated job domain will be returned.

- DeleteJobsDomain(string connection, string id)

    Deletes a job domain. If the job domain was deleted successfully, the method will return TRUE.

- UpdateDomainSectionDefinitionConfiguration(string connection, string domainID, DMASectionDomainConfig\[\] configuration)

    This method, which was formerly named SaveJobsSectionDomainConfig, updates all client information of each section definition in JobDomain.VisualStructure.

##### Methods to manage job section definitions

- CreateJobsSectionDefinition(string connection, string domainID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now creates a section definition in the specified domain. If the section definition was created successfully, the section definition ID will be returned.

- GetJobsSectionDefinitions(string connection)

    Retrieves all section definitions.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionsV2 method instead (see below).

- GetJobsSectionDefinitionsV2(string connection, string domainID)

    Retrieves all section definitions from the specified domain and parses them using the client information in the VisualStructure of the domain in question.

- GetJobsSectionDefinition(string connection)

    Retrieves a specific section definition.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionV2 method instead (see below).

- GetJobsSectionDefinitionV2(string connection, string domainID. string sectionDefinitionID)

    Retrieves a specific section definition from the specified domain and parses it using the client information in the VisualStructure of the domain in question.

- UpdateJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now updates the specified section definition in the specified domain. If the section definition was updated successfully, the section definition ID will be returned.

- DeleteJobsSectionDefinition(string connection string sectionDefinitionID)

    > [!NOTE]
    > This method is no longer supported. It will return an error indicating that you should use the new DeleteJobsSectionDefinitionFromDomain method instead (see below).

- DeleteJobsSectionDefinitionFromDomain(string connection, string domainID, string sectionDefinitionID)

    Removes the specified section definition from the specified domain and the client information for that domain from the VisualStructure.

    > [!NOTE]
    > This method does not physically delete a section definition. It only removes the link between the section definition and the job domain.

- UnhideJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID)

    Unhides the specified section definition of the specified domain.

- UpdateSectionDefinitionFieldOrder(string connection, string domainID, string sectionDefinitionID, string\[\] fieldOrder)

    Updates the field order in the specified section definition of the specified domain.

##### Methods to manage job section definition fields

- AddOrUpdateJobsSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, DMASectionDefinitionField field, DMAJobFieldPossibleValueUpdate\[\] possibleValueUpdates)

    Adds or updates a section definition field in the specified section definition of the specified domain.

- DeleteJobsSectionDefinitionField(string connection, string sectionDefinitionID, string fieldID)

    Removes a section definition field from the specified section definition of the specified domain.

- UnhideJobSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, string fieldID)

    Unhides the specified section definition field in the specified section definition of the specified domain.

##### Methods to manage jobs

- DeleteJobs(string connection, string domainID, string\[\] jobIDs)

    Deletes the specified jobs and returns an DMARemoveInfo object containing an array with all successful and failed removals.

##### Methods to manage job templates

- GetJobTemplates(string connection)

    Retrieves all job templates.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobTemplatesV2 method instead (see below).

- GetJobTemplatesV2(string connection, string domainID)

    Retrieves all job templates for the specified domain.

### DMS Mobile apps

#### Jobs app: Job domains \[ID_25889\]\[ID_26428\]

In the Jobs app, it is now possible to have different job domains, each with their own set of job section descriptions.

- If, in the top-left corner of the jobs list, you select a job domain from the list, the jobs list will be filtered and will list only the jobs associated with the selected job domain.

- In configuration mode, you can select the job domain in the top-left corner of the screen, and then configure the job sections within the selected domain. The *New*, *Edit* and *Delete* buttons on the right of the job domain selection box allow you to add a new domain, edit the name of the selected domain or delete the selected domain.

    > [!NOTE]
    > When you upgrade from a DataMiner system without job domains, all existing job section definitions will be stored in a job domain named “DefaultJobDomain”.
    >
    > Note that, if necessary, it is possible to rename this default job domain.

#### Jobs app: Managing job attachments no longer requires explicit Delete permission \[ID_25961\]

From now on, managing job attachments only requires the *Jobs \> UI available* and *Jobs \> Add/Edit* user permissions. The *Jobs \> Delete* user permission is no longer required.

#### Jobs app: Enhanced job section configuration \[ID_25977\]

In the Jobs app, job section configuration has been enhanced.

When you add a new job section (by clicking a black or purple dot) or edit an existing job section (by clicking the edit button in the section’s header), a popup window will now appear, allowing you to enter or modify the properties of that section.

#### Jobs app: Tracking the history of job field values \[ID_26016\]

All changes made to job field values will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-job”).

A HistoryChange record associated with a job field value change will contain SectionChange objects and FieldValueChange objects.

A SectionChange object has the following properties:

| Field             | Description                                                                                    |
|-------------------|------------------------------------------------------------------------------------------------|
| SectionID         | The ID of the section in which fields were created, updated or deleted.                        |
| FieldValueChanges | A list of FieldValueChange objects (one for every field that was created, updated or deleted). |

A FieldValueChange object has the following properties:

| Field             | Description                                                                          |
|-------------------|--------------------------------------------------------------------------------------|
| FieldDescriptorID | The ID of the FieldDescriptor.                                                       |
| CrudType          | The type of change, indicating whether the field was added, updated or deleted.      |
| ValueBefore       | The value before the change. When CrudType is “Created”, this property will be Null. |
| ValueAfter        | The value after the change. When CrudType is “Deleted”, this property will be Null.  |

> [!NOTE]
>
> - If, for some reason, tracking changes to jobs would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a job is deleted, all HistoryChange records associated with this job will also be deleted, and a new HistoryChange record will be added to indicate when the job was deleted and by whom.

#### Enhanced visualization of disabled text boxes \[ID_26193\]

Disabled text boxes in e.g. interactive Automation scripts will now automatically be optimized as to size and will have a scrollbar when needed.

#### User menu now has a 'Sign out' command \[ID_26254\]

In all mobile apps (Monitoring, Dashboards, Jobs, etc.), the user menu in the top-right corner of the screen now has a “Sign out” command.

#### Monitoring & Dashboards apps: Number groups in numeric parameter values will now be separated by a thin space \[ID_26394\]

In the Monitoring app and the Dashboards app, three-digit number groups in numeric parameter values will now by default be separated by a thin space. This will make large numbers more legible.

### DMS tools

#### SLNetClientTest tool: Generating SMIv2 MIB files \[ID_26320\]

In the SLNetClientTest tool, you can now generate SMIv2 MIB files for SNMP managers of type SNMPv2 and SNMPv3.

To do so, go to *Advanced \> Tests \> Generate MIB for SNMP Manager*, select an SNMP manager and click *Generate*.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

## Changes

### Enhancements

#### DataMiner Maps: Enhanced retrieval of marker alarm severities \[ID_24363\]

Due to a number of enhancements, overall performance has increased when retrieving marker alarm severities.

#### SLAnalytics: Alarm focus enhancements \[ID_25591\]

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time.

Due to a number of enhancements, overall performance of this alarm focus feature has now increased.

#### Protocols - Serial clients: Enhanced locking behavior \[ID_25647\]

A number of enhancements have been made to the locking behavior of serial client elements.

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when displaying icons on trend graphs \[ID_25798\]

Due to a number of enhancements, overall performance has increased when displaying icons on trend graphs to indicate behavioral anomalies.

#### DataMiner Cube - Automation: Dummies, parameters and memory files now sorted in the order in which they were added to the script \[ID_25897\]

Up to now, the dummies, parameters and memory files added to an Automation script were sorted naturally. From now on, they will be sorted in the order in which they were added to the script.

#### SLAnalytics: Sending messages asynchronously has been optimized \[ID_25942\]

Due to a number of enhancements, sending messages asynchronously has been optimized.

#### DataMiner Cube - Visual Overview: Colors linked to the Cube theme will now be changed immediately when you change the Cube theme \[ID_26045\]

When, in a Visio drawing, you linked some colors to the colors used in the DataMiner Cube theme, then those colors will now immediately be changed when you change the DataMiner Cube theme. You will no longer have to close and re-open the Visio drawing to have the changes take effect.

#### Service & Resource Management: Optimized functions.xml generation \[ID_26060\]

The generation of functions.xml files has been optimized. Function names no longer have an “SRMFunction\_” prefix and the \<Graphical> tag of the parent function will now automatically be added to the generated functions.xml file.

#### Dashboards app: Enhanced performance of CPE feed component \[ID_26082\]

Due to a number of enhancements, overall performance of the CPE feed component has increased.

#### Jobs app: Time range validation when creating jobs \[ID_26166\]

From now on, due to a number of enhancements as to data validation, it will no longer be possible to create a job with an invalid time range.

#### DataMiner Cube: Embedded Chromium web browser engine updated from v63 to v81 \[ID_26171\]

The embedded Chromium web browser engine has been updated from v63 to v81.

#### Automation: UnSetFlag method added to Intellisense \[ID_26176\]

In the Automation module, the *UnSetFlag* method has now been added to Intellisense.

#### Text will now be written to the log files using UTF-8 encoding \[ID_26194\]

From now on, text will be written to the log files using UTF-8 encoding.

#### Profiles app: Enhanced performance when loading \[ID_26197\]

Due to a number of enhancements, overall performance of the Profiles app has increased when loading, especially on systems with a large amount of profiles.

#### DataMiner Maps: Enhanced performance when retrieving EPM-related data \[ID_26216\]\[ID_26233\]

Due to a number of enhancements, overall performance has increased when retrieving EPM-related data.

#### Trending of column parameters with measurement type 'string' is now also supported \[ID_26230\]

From now on, trending of column parameters with measurement type set to “string” is also supported.

#### Dashboards: Column parameters with advanced naming supported for trend statistics visualization \[ID_26240\]

The *Trend statistics* visualization in the new Dashboards app now supports column parameters from tables that use advanced naming.

#### DataMiner Cube - Alarm Console: Reduced memory usage \[ID_26285\]

Due to a number of enhancements, overall memory usage of the Alarm Console has been reduced.

#### Dashboards app: Embedded Chromium web browser engine updated to v81 \[ID_26296\]

The embedded Chromium web browser engine has been updated to v81.

#### Enhanced performance when displaying and updating parameter values \[ID_26382\]

Due to a number of enhancements, overall performance has increased when displaying and updating parameter values, both in Data Display and Visual Overview.

#### DataMiner Cube: Enhanced way of saving information about the last user who logged in \[ID_26483\]

When DataMiner Cube is shut down, it saves information about the last user who logged in. The formatting of that user data has now been enhanced.

### Fixes

#### SLAnalytics: Memory usage would increase due to a buffering issue \[ID_25844\]

In some cases, the overall memory usage of the SLAnalytics process would increase due to a buffering issue.

#### SLAnalytics: Parameter information of inactive elements would incorrectly not get removed from the cache \[ID_25851\]

Up to now, parameter information of inactive elements would incorrectly not get removed from the cache.

#### Problem with SLDMS due to memory issues \[ID_25890\]

In some cases, an error could occur in SLDMS due to memory issues.

#### DataMiner Cube: When, in the Generic DVE Linker Table, a link associated with a virtual function was changed while its element card was open, its parameters would not get updated \[ID_25913\]

When, in the Generic DVE Linker Table, a link related to a virtual function was added, updated or removed while its element card was open in DataMiner Cube, the parameters of that function would incorrectly not get updated.

#### SLAnalytics: Element state changes and element deletions would not be processed correctly when behavioral anomaly detection was disabled \[ID_25929\]

Up to now, when behavioral anomaly detection was disabled, in some cases, element state changes and element deletions would not be processed correctly.

#### Service & Resource Management: State of ReservationInstance would incorrectly be set to Interrupted when it was updated after a DMA restart \[ID_25938\]

When you restarted a DataMiner Agent with an ongoing ReservationInstance and then updated the end time of that ongoing ReservationInstance after the restart, in some rare cases, the state of the ReservationInstance would incorrectly be changed from “Ongoing” to “Interrupted”.

#### Web Services API v1: GetElementConfiguration method returned incorrect SNMP version \[ID_25964\]

In some cases, the *GetElementConfiguration* web method returned the *SNMPVersion* in a *DMAElementSNMPPortInfo* instance as 0 when it should have been 1 or 2.

#### Duplicate table change notifications would be sent from SLElement to SLDataGateway when using history sets in combination with table updates \[ID_25987\]

When history sets were used in combination with table updates, in some cases, duplicate table change notifications would incorrect be sent from SLElement to SLDataGateway when the values remained stable.

#### Hotfixes not properly validated during installation \[ID_25991\]

In some cases, it could occur that hotfixes were not properly validated during installation, so that a hotfix could be installed on an incompatible version of DataMiner.

#### When adding or editing an element, some fields would not correctly be saved into the element.xml file \[ID_25994\]

When adding or editing an element, in some cases, the contents of a number of fields (e.g. GetCommunity, SetCommunity, etc.) would not correctly be saved into the element.xml file.

#### Failover: Backup agent would lose its connection to the virtual agent \[ID_26025\]

When, in a Failover setup with a Cassandra database, the backup agent was online, in some cases, it would lose its connection to the virtual agent.

#### DataMiner was not able to correctly parse the Cassandra.yaml file at startup \[ID_26041\]

At startup, in some cases, DataMiner was not able to correctly parse the IP addresses of the seed nodes when reading the Cassandra.yaml file.

#### DataMiner Cube - Alarm Console: Alarm duration indicator was missing \[ID_26044\]

In the Alarm Console, in some cases, the alarm duration indicator would not be shown in the Time column of a certain alarm, even though the Show alarm duration indicator option was enabled in the hamburger menu of the Alarm Console.

The problem would occur in the following situations:

- When you expanded a correlation alarm, the alarm duration indicator of the source alarms would disappear.
- When, for a particular alarm, an update was received while its history was expanded, the alarm duration indicator of the alarms in the history list would disappear.

#### Automation scripts: Problem when a parameter specified in an email action contained a double quote character \[ID_26046\]

When, in an Automation script, you specified a parameter containing a double quote character in an email action configured to send a report, in some cases, it would not be possible to save the script.

#### DataMiner Cube - Trending: Zoom buttons in top-right corner of a trend graph window would incorrectly not be displayed \[ID_26068\]

When you opened a trend graph, e.g. by clicking the trend graph icon next to a parameter shown on an element card, in some cases, the zoom buttons (Last 24 hours, Week to date and Month to date) in the top-right corner would incorrectly not be displayed.

#### Deadlock between SLNet and SLDataGateway during a DataMiner startup or a Failover switch \[ID_26074\]

Due to a flushing issue in SLNet, in some cases, a deadlock could occur between SLNet and SLDataGateway during a DataMiner startup or a Failover switch.

#### DataMiner Cube - Visual Overview: Problem when initializing a Visio page with service shapes \[ID_26079\]

In some cases, an exception could be thrown while initializing a Visio page containing service shapes.

#### MySQL: Problem with delete queries trying to delete trend records for elements that were not being trended \[ID_26085\]

On systems with a MySQL database, in some cases, a delete query would incorrectly try to delete trend records for an element that was not being trended.

#### DataMiner Cube - Visual Overview: No tool tip shown when SetVar shape was configured using legacy syntax \[ID_26087\]

In some cases, no tool tip would be shown when you had used legacy syntax to configure a tool tip on a shape (e.g. SetVar set to "varA:X:Y" and SetVarOptions set to "Control=Shape").

#### DataMiner Cube - Element Connections: Problem when swapping connections \[ID_26098\]

When, in the Element Connections app, you swapped two connections, in some cases, the connection configuration would be incorrect or a connection would incorrectly be duplicated.

#### Service & Resource Management: It was incorrectly possible to create or update profile parameters that linked to non-existing mediation snippets \[ID_26110\]

Up to now, it would incorrectly be possible to create or update profile parameters that linked to non-existing mediation snippets.

#### Incorrect message shown after a successful DataMiner upgrade operation \[ID_26114\]

After a DataMiner upgrade operation, in some cases, a “DataMiner is currently upgrading” error would be shown indefinitely, despite the fact that all agents had been upgraded successfully.

#### Failover: Problem when switching over the first time after migrating from MySQL to Cassandra \[ID_26116\]

When, in a Failover setup, the first switch-over occurred after migrating from MySQL to Cassandra, in some cases, a DataMiner run-time error alarm would be generated.

#### ResourceManager module would no longer initialize after a DataMiner restart \[ID_26117\]\[ID_26309\]

In some cases, the ResourceManager module would no longer initialize after a DataMiner restart.

#### Problem with SLManagedScripting due to a locking issue \[ID_26139\]

In some rare cases, threads could get stuck in SLScripting due to a locking issue.

#### DataMiner Cube: Incorrect error would be logged when opening a view card without linked EPM object in an EPM environment \[ID_26141\]

When, in an EPM environment, you opened a view card without linked EPM object, in some cases, an incorrect error would be logged.

#### Dashboards app - Service definition component: When a node action was executed, all action buttons of other nodes with the same action configured would be set to 'loading' \[ID_26145\]

In a service definition component, in some cases, all nodes with the same action configured would set the state of their action button to “loading” when the action was executed on one of those nodes.

#### Sidebar docking position user setting not working in non-English Cube \[ID_26165\]

If Cube was set to a different language than English, it could occur that it was not possible to change the position of the Cube sidebar via the user settings.

#### DataMiner Cube would become unresponsive when no domain user pictures could be retrieved \[ID_26182\]

In some cases, DataMiner Cube could become unresponsive when no domain user pictures could be retrieved.

#### SLAnalytics: New alarms generated while SLAnalytics was stopped would incorrectly not be assigned an alarm focus score when SLAnalytics was restarted \[ID_26186\]

When a new alarm was generated while SLAnalytics was stopped, in some cases, that alarm would incorrectly not get assigned an alarm focus score when SLAnalytics was restarted.

#### View synchronization could cause SLDataMiner to leak memory \[ID_26190\]

On large DataMiner systems, in some cases, a view synchronization could cause SLDataMiner to leak memory.

#### Dashboards: Clicking the icon of a parameter component would incorrectly not open the associated trend card in the Monitoring app \[ID_26213\]

When, in the Dashboards app, you click the icon of a parameter component, the trend card of the parameter in question should open in the Monitoring app. However, in some cases, this did not happen due to an incorrect key being passed from the Dashboards app to the Monitoring app.

#### Problem with user permissions caused certain parameters of an enhanced service not to be displayed \[ID_26222\]

In some cases, the user permissions configured for the hidden element of an enhanced service would differ from those configured for the enhanced service itself. This would cause certain parameters of the enhanced service not to be displayed.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_26227\]

When protocol buffer serialization was being used, a “Failed to set up ProtoBuf” error could be thrown when a DMA and a client were running different DataMiner versions.

#### Jobs app: Problem when creating custom data tables \[ID_26237\]

In the Jobs app, in some rare cases, an exception could be thrown when two custom data tables were created simultaneously.

#### Service & Resource Management: System functions were not synchronized when a new agent was added to an existing DataMiner System \[ID_26238\]

When a new agent was added to an existing DataMiner System, in some cases, the system functions would not be synchronized.

#### Problem when a table cell value was masked while being retrieved \[ID_26250\]

In some cases, an error could occur when a table cell value was masked while it was being retrieved.

#### Memory leak when adding or deleting rows in the DCF interface table \[ID_26256\]

When, in an element with DCF interfaces, rows were added or deleted in the DCF interface table, in some cases, a memory leak could occur.

#### Automation: Date and time not adapted to local time zone in calendar component \[ID_26258\]

If an interactive Automation script used a calendar component, it could occur that the date and time in the component were not adapted to the local time zone.

#### DataMiner Cube - Data Display: Time control values would incorrectly change when you edited them \[ID_26278\]

Due to a rounding issue, in some cases, values displayed in a time control would change when you edited them.

#### DataMiner Cube - Services: Exclude setting specified when creating a service would incorrectly change to an include setting when editing that service afterwards \[ID_26281\]

When you created a service with exclude conditions in combination with conditional alarm severity influence settings, in some cases, the exclude setting would incorrectly change to an include setting when editing that service afterwards.

#### Problem when multiple FillArray calls simultaneously tried to update the same table \[ID_26287\]

When multiple FillArray calls simultaneously tried to update the same table, in some cases, an error could occur due to a locking issue.

#### Dashboards app - Service definition component: Hidden nodes would incorrectly re-appear when the service definition was changed \[ID_26294\]

When nodes were hidden based on node ID or function definition, in some cases, nodes would incorrectly re-appear when the service definition was changed.

Also, a number of other, minor fixes have been made to the component in question.

#### DataMiner Cube - Elements: Actions listed in the warning message that appears when changing the protocol version of an element would not be formatted correctly \[ID_26297\]

When you are about to change the protocol version of an element, a popup message will appear. Apart from warning you about the consequences, that message also lists the (manual) actions that are required afterwards. Up to now, in some cases, that list of actions would not be formatted correctly.

#### An SNMP table configured to retrieve data via a bulk operation would not get filled in when one of the responses contained an error \[ID_26333\]

When an SNMP table was configured to retrieve data via a bulk operation (e.g. multiple get), up to now, the table would only get filled in when all requests had received a correct response. One response containing an error would cause the entire table to not get filled in.

From now on, each time a correct response is received, the data in that response will be returned to SLProtocol for processing.

#### Ticketing/Cassandra: Problem when retrieving a ticket that had just been added or updated \[ID_26348\]

On systems where the ticketing data is stored in a Cassandra database, in some cases, it would not be possible to retrieve a ticket immediately after it was created. Also, when a ticket was retrieved immediately after it had been updated, in some cases, the ticket data from before the update would incorrectly be retrieved.

#### Memory leak in SLDataGateway \[ID_26361\]

In some cases, the SLDataGateway process would leak memory.

#### Monitoring app: Client timezone setting was disregarded when displaying timestamps in trend graphs \[ID_26368\]

In some cases, the Monitoring app would incorrectly disregard the client timezone setting when displaying timestamps in trend graphs.

#### DataMiner Cube - Alarm Console: Miscellaneous issues \[ID_26396\]

A number of minor issues have been fixes in the Alarm Console:

- When an alarm in the Active Alarms tab page was clicked, in other words, marked as read, in some cases, the alarm would incorrectly be set to unread again when you opened a tab page of type “sliding window” that contained the alarm in question.

- When you opened a tab page of type “sliding window” and kept it open while a number of active alarms were cleared, in some cases, when you opened a new tab page of type “sliding window” with an identical window size, the number of unread alarms in the first tab page would not be equal to the number of unread alarms in the second tab page.

- When the alarms in a particular tab page were grouped by Time, in some cases, the sorting would be reversed each time you changed the Automatically grouped according to arrangement setting.

- In some cases, similar alarms would have different parameter descriptions. One alarm would e.g. show “Temperature” while another alarm would show “Temperature A”.

#### DataMiner Cube: Module names in side bar not translated when UI language was set to a language other than English \[ID_26402\]

When, in DataMiner Cube, the UI language was set to a language other than English, in some cases, the names of the modules in the side bar would not be translated.

#### Active alarms would not be retrieved correctly from the database \[ID_26420\]

In some cases, an internal exception could be thrown, causing the active alarms not to be retrieved correctly from the database.

#### Jobs app: Problem with 'New' and 'Save' buttons \[ID_26474\]

In the Jobs app, in some cases, the *New* button would not be shown in the subheader.

Also, in some cases, clicking the *Save* button would not cause a job to be saved.

#### Jobs app: Problem when exporting a job to PDF \[ID_26484\]

In some cases, it would not be possible to export a job to a PDF file.

#### Jobs app: Problem when updating a job with bookings \[ID_26486\]

In some cases, an error could occur when you updated a job with bookings.

#### Jobs app: Bookings list would not be updated correctly after adding, editing or deleting a booking \[ID_26487\]

In the Jobs app, in some cases, the bookings list would not be updated correctly after adding, editing or deleting a booking.

#### DataMiner Cube - Alarm Console: Problem when a sliding window alarm tab was present when clearing alarms correlated by the alarm storm prevention mechanism \[ID_26494\]

When too many alarms are generated for the same parameter, an alarm storm prevention mechanism is triggered, which groups all those alarms into one correlated alarm. When those alarms got cleared, in some cases, an error could occur when an alarm tab of type “sliding window” was present in the Alarm Console.

#### Problem when opening a Visio file in an HTML5 app \[ID_26610\]

In some cases, an exception could be thrown when opening a Visio file in an HTML5 app (e.g. Monitoring).

## Addendum CU1

### CU1 enhancements

#### Cassandra: Enhanced performance when deleting element data \[ID_26639\]

Due to a number of enhancements, overall performance has increased when deleting element data from a Cassandra database.

### CU1 fixes

#### Cassandra: Alarm information would incorrectly be saved in the timetrace table when multiple alarms were generated simultaneously \[ID_26768\]

When multiple alarms were generated at the same time, in some rare cases, alarm information would not correctly be saved in the timetrace table.

#### DataMiner Cube: Legacy resources and legacy bookings could no longer be managed on systems with a MySQL database \[ID_26774\]

On systems with a MySQL database, in some cases, it would no longer be possible to use the Resources and Bookings apps to manage legacy resources and legacy bookings.

#### Cube Launcher: Problem when system locale was set to a language other than English \[ID_26815\]

When Cube Launcher was used on a client computer that had its system locale set to a language other than English, in some cases, an exception could be thrown.
