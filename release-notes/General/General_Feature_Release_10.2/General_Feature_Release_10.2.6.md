---
uid: General_Feature_Release_10.2.6
---

# General Feature Release 10.2.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### New read-only service properties \[ID_29978\] \[ID_33196\] \[ID_33363\]

When a service is created or updated, the following read-only properties will now be filled in automatically:

| Property    | Description                                                |
|-------------|------------------------------------------------------------|
| Created     | DateTime (UTC) at which the service was initially created. |
| Created by  | User name of the user who created the service.             |
| Modified    | DateTime (UTC) at which the service was last modified.     |
| Modified by | User name of the user who last modified the service.       |

> [!NOTE]
>
> - When you upgrade to DataMiner version 10.2.6, a check will be performed to make sure your system includes an up-to-date SRM solution. If the installed SRM solution is not up-to-date, you will be asked to update it before continuing with the DataMiner upgrade.
> - These properties will only be added to existing services the first time those services are updated.
> - These properties will not be available in alarms that are included in a service.

#### DataMiner Object Model: Defining a TTL for DomTemplates, DomInstances and DomInstance history \[ID_32662\]

It is now possible to define a "time to live" property for the following types of DomManager objects:

| Object type                        | Property              |
|------------------------------------|-----------------------|
| DomInstance                        | DomInstanceTtl        |
| DomTemplate                        | DomTemplateTtl        |
| HistoryChange (DomInstanceHistory) | DomInstanceHistoryTtl |

Times are defined as TimeSpan objects. By default, these will be set to TimeSpan.Zero, i.e. no TTL. When, for a particular type of object, the TTL is set to e.g. 1 year, those objects will be automatically removed when they were last modified more than a year ago.

Example:

```csharp
var moduleSettings = new ModuleSettings("example")
{
    DomManagerSettings = new DomManagerSettings()
    {
        TtlSettings = new TtlSettings()
        {
            DomTemplateTtl = TimeSpan.Zero,                 // No TTL
            DomInstanceHistoryTtl = TimeSpan.FromDays(365), // 1 Year
            DomInstanceTtl = TimeSpan.FromDays(730)         // 2 Years
        }
    }
};
```

> [!NOTE]
> TTL settings are checked every 30 minutes. When you configure a very short TTL (e.g. 15 minutes), keep in mind that the objects in question will only be removed during the next cleanup cycle.

#### SLMessageBroker log files are now split per process and limited to 3 MB \[ID_33126\]

The SLMessagebroker log files are now split per process and limited to 3 MB.

These log files are stored in C:\\Skyline DataMiner\\Logging\\SLMessageBroker and are named SLMessageBroker\_\[processname\].txt. When a file exceeds the 3-MB limit, it is renamed to SLMessageBroker\_\[processname\]\_1.txt and a new file is created named SLMessageBroker\_\[processname\]\_2.txt.

> [!NOTE]
> These log files will not be deleted when the DataMiner Agent is upgraded.

#### SetAlarmStateMessage can no longer be used to change the alarm state of an incident \[ID_33273\]

From now on, it will no longer be possible to change the alarm state of an incident by means of a SetAlarmStateMessage. If you attempt to do so, an exception will be thrown.

#### DataMiner upgrade: When VerifyClusterPorts prerequisite fails the user will now receive more information on why it failed \[ID_33979\]

<!-- MR 10.2.0 [CU6] - FR 10.2.8 [CU0] -->

When, during a DataMiner upgrade, the VerifyClusterPorts prerequisite fails, you will now receive more information on why it failed. For example, the DMS.xml file could contain faulty IP addresses or NATS may have silently failed.

### DMS Security

#### SAML authentication: Azure Active Directory B2C now also supported as identity provider \[ID_32714\]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.6 -->

For external authentication using SAML, DataMiner now also supports Azure Active Directory B2C as an identity provider.

Also, when creating a DataMiner user, using an email address as user name is now mandatory.

> [!NOTE]
> If, in DataMiner.xml, the default user name of an identity provider is not a valid email address, you can optionally add a \<PreferredLoginClaim> element that refers to a claim that contains a valid email address.

#### SLSSH: Enhanced host key verification algorithm support \[ID_33132\]

When acting as an SSH client, DataMiner now supports the following host key verification algorithms (in order of preference):

- ecdsa-sha2-nistp521 (new)
- ecdsa-sha2-nistp384 (new)
- ecdsa-sha2-nistp256 (new)
- ssh-rsa
- ssh-dss

### DMS Cube

#### DataMiner Cube - Resources app: Function instance name can now be updated \[ID_32811\]

When updating a resource in the Resources app, it is now possible to change the function instance name, i.e. the name of the DVE element linked to a function resource.

> [!NOTE]
>
> - It is recommended to modify DVE names via the resource instead of via the main DVE element.
> - Names of DVE elements can also be modified in *General Parameters \> Resource Info \> DVE Table*.

#### Visual Overview: Passing Interactive Automation script output to session variables \[ID_32874\]

Similar to regular Automation scripts, interactive Automation scripts are now also able to pass their output to session variables in Visual Overview.

> [!NOTE]
> When configuring the Execute shape, it is recommended to specify both the NoConfirmation option and the CloseWhenFinished option in the value of the Execute data field.

#### Visual Overview - Resource Manager component: Enhancements with regard to selecting bookings in the timeline \[ID_32938\]

A number of enhancements have been made with regard to selecting bookings in the timeline area of an embedded Resource Manager component.

- When you select a booking, the corresponding resource band and all occurrences of that booking will be selected.
- When you unselect a booking, the corresponding resource band and all occurrences of that booking will also be unselected.
- The reservation variable and the resource variable will always contain the booking and the resource selected in the timeline.
- When you remove a resource band, the corresponding resource variable will be cleared.

#### Trending - Behavioral anomaly detection: Flatline change points can now also be detected for history set parameters that are set nearly in real time \[ID_32993\]

Flatline change points can now also be detected for history set parameters that are set nearly in real time, i.e. parameters of which the incoming changes never have a delay larger than 10 minutes.

#### Alarm Console: Manually creating incident alarms even when 'Automatic incident tracking' is disabled \[ID_33000\]

From now on, in the Alarm Console, you will be able to manually create incident alarms (i.e. alarm groups) even when the “Automatic incident tracking” option is disabled.

- When you right-click an alarm that is not part of any alarm group, you will be able to click the “Add to incident” option. If you do so, a window\* will appear, asking you

  - to create a new incident (i.e. a new alarm group) and add the alarm to it, or
  - to add the alarm to an existing alarm group.

These manually created groups will always be visible in active alarm tabs, even when the “Automatic incident tracking” option is disabled.

*\*This window lists all existing incidents. From now on, you will be able to sort this list by clicking a column header. Also, a search box has now been added to allow you to search for a particular incident.*

#### Visual Overview: Resource usage now updated in real time \[ID_33001\] \[ID_33156\] \[ID_33497\]

From now on, resource usage will be updated in real time. This means that “\[Resource:\<GUID>,InUse\]” placeholders and Info data fields of type “IN USE” will now be updated without having to close and re-open cards.

Also, from now on, “\[Resource:\<GUID>,InUse\]” placeholders and Info data fields of type “IN USE” can be used in any element shape, provided it has “UseResource=True” in a shape data field of type Options.

#### Alarm Console - Automatic incident tracking: Moving alarms from one alarm group to another \[ID_33036\]

In the Alarm Console, you can now move alarms from one incident (alarm group) to another.

- When you right-click an alarm that is part of an alarm group, you will now be able to click the “Move to another incident” option. If you do so, a pop-up window will appear, asking you to either create a new incident or select another, existing incident.

#### Alarm Console: Additional actions to be performed on incidents \[ID_33056\]

From now on, when you right-click an incident (alarm group), you will be able to perform the following additional actions:

- Take ownership
- Release ownership
- Force release ownership
- Add a comment

If you right-click a manually created incident, you will also be able to select *Clear alarm*. When you clear a manually created incident, the alarm group will be cleared and all the base alarms will again be added to the Alarm Console.

#### Alarm templates - Anomaly detection: Configuring alarms for flatline changes \[ID_33123\] \[ID_33139\] \[ID_33171\]

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters. From now on, you can also enable this for flatline changes.

1. Click the cogwheel button in the top-right corner of the alarm template editor.
1. Select the option *Advanced configuration of anomaly detection*. Four extra columns will be displayed in the template editor.
1. In the *Flatline monitor* column, click the toggle button to enable or disable alarms for flatline changes.

#### Alarm Console - Automatic incident tracking: Manually created incidents (alarm groups) will have their alarm focus score set to 0 \[ID_33130\]

Manually created incidents (alarm groups) will have their alarm focus score set to 0.

#### Visual Overview: ServiceManager component functionality expanded to support Process Automation UI \[ID_33187\]

To make it possible to show an overview of Process Automation service definitions in Visual Overview and filter these, the functionality of the *ServiceManager* component has been expanded.

##### interface=definitions component option

When you embed the Services module in Visio using the shape data field *Component* with the value *ServiceManager*, in the *ComponentOptions* shape data field, you can now use the option *interface=definitions* to only show the *Definitions* > *Recent* tab of the Services module. All existing options and variables have been made compatible with this option.

##### Filter shape data

If you use the *interface=definitions* component option described above, you can now also combine a *Filter* shape data field with the *ServiceManager* component. This allows you to filter the service definitions in the list, in the same way as in a *ListView* component. The following properties are supported for the filter:

- Name (String)
- Description (String)
- IsTemplate (Boolean)
- ID (GUID)
- CreatedBy (String)
- CreatedAt (DateTime)
- LastModifiedBy (String)
- LastModified (DateTime)
- NodeFunctionIDs (List\<Guid>)
- Properties (IDictionary\<string, dynamic>)
- ServiceDefinitionType (Int): This is an enum with the following possible values:

  - 0 = Default (representing the type "SRM" in Cube)
  - 1 = ProcessAutomation (representing the type "Skyline Process Automation" in Cube)
  - 2 = CustomProcessAutomation (representing the type "Custom Process Automation" in Cube)

Examples:

- This filter will only show service definitions of type "Skyline Process Automation" or "Custom Process Automation":

    | Shape data field | Value                                                                                                            |
    |--------------------|------------------------------------------------------------------------------------------------------------------|
    | Filter             | ServiceDefinition.ServiceDefinitionType\[Int32\] == 1 \|\| ServiceDefinition.ServiceDefinitionType\[Int32\] == 2 |

- This filter will only show service definitions with the property *Virtual Platform* set to VPA:

    | Shape data field | Value                                                    |
    |--------------------|----------------------------------------------------------|
    | Filter             | ServiceDefinition.Properties."Virtual Platform" == "VPA" |

##### New HideAddButton and HideDeleteButton component options

The following options can now also be specified in the *ComponentOptions* shape data field for a *ServiceManager* component:

- **HideAddButton=**: If this option is set to "true", no options to add a service definition will be displayed.
- **HideDeleteButton=**: If this option is set to "true", no options to delete a service definition will be displayed.

#### Alarm Console: Assigning a ticket to an incident (alarm group) \[ID_33199\]

In the Alarm Console, it is now possible to assign tickets to incidents (alarm groups).

- To assign a ticket to an incident, right-click the incident (alarm group) and select *Ticket \> New*.
- To view a ticket assigned to an incident, right-click the incident (alarm group), select *Ticket*, and then select the ticket you want to view.

#### Alarm Console - Automatic incident tracking: Menu commands to manipulate alarm groups will no longer be available when DataMiner Agent does not support manually creating, updating and renaming incidents \[ID_33212\]

When Cube is connected to a DataMiner Agent that does not yet support manually creating, updating and renaming incidents (alarm groups), from now on, the menu commands to manipulate alarm groups will no longer be available.

#### DataMiner Cube: Start window enhancements \[ID_33219\]

A number of enhancements have been made to the start window of the DataMiner Cube desktop app:

- Settings menu (cogwheel icon in bottom-right corner)

  - New *About* box with version information.
  - All menu items now have icons in front of them.

- When you right-click an agent,

  - you can now click *Open in browser* to connect to that agent using a browser version of Cube, and
  - all context menu items now have icons in front of them.

- When agents/clusters are arranged in named groups, the context menu of the DataMiner Cube system tray icon will now contain submenus per named group.

- The message that is displayed after a start window update will no longer show any technical information.

#### Alarm templates: Anomaly detection alarms will now be sent regardless of the level of change \[ID_33281\]

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters.

Up to now, this type of alarm would only be generated if a behavioral change of a parameter was considered large enough compared to previous behavioral changes. From now on, as soon as you enable anomaly detection for a certain type of change point, these alarms will be generated, regardless of the level of change.

#### Desktop app - Start window: New 'HTTP or HTTPS' setting \[ID_33289\]

Up to now, when a DataMiner Agent had been added to the start window of the DataMiner Cube desktop app at a time when only HTTP was available, Cube would no longer switch to HTTPS when that protocol became available and HTTP got blocked.

When you add a DataMiner Agent to the start window, in the Advanced settings, you can now set the *Transport* setting to either “HTTPS only” or “HTTP or HTTPS”. If you choose the latter option, Cube will use HTTP by default. When HTTP is not available, it will try to use HTTPS instead. From that point onwards, the transport setting will automatically be switched to “HTTPS only”, so HTTPS will be used for all following sessions.

> [!NOTE]
> If a DataMiner Agent is configured to use only HTTPS, Cube will not fall back to HTTP, even when you have chosen the “HTTP or HTTPS” option.

#### Data Display: Replacing the separator when specifying a SystemName containing colons in an EPM object link \[ID_33295\]

Since DataMiner version 10.2.3, there is a new way of adding links to EPM objects in a Data Display table. When, in a protocol, you configure a cell button as shown below, the table cell will display the SystemType and SystemName defined in the EPM object. Clicking the link will open a new card for that object.

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

The discreet value can contain the SystemType and SystemName of the object, or a reference like “{pid:530}”.

If you know the type of the EPM object, you can add a type prefix (epm or view), followed by an equal sign and (a reference to) the identifier, and if you want to specify the page to be selected by default, you can add a suffix to the identifier in the \<Value> tag containing the root page name and the page name, separated by a colon.

If the SystemName contains colons (e.g. a MAC address), then you can now replace the default separator (i.e. colon) by another one (e.g. a pipe character) by placing a \[sep:XY\] prefix in front of the system name. See the following example:

*\<Value type="open">{EPM=***\[sep::\|\]***CPE/'00:01:08:01:08:01\|DATA\|CPE Frequencies}\</Value>*

#### Data Display: Context menu of URL parameters now contains copy commands \[ID_33321\]

In Data Display, the context menu of a URL parameter will now contain the following copy commands:

- Copy ‘\<URL>’: Copies the URL to the Windows Clipboard.

- Copy value to editor: Copies the URL to the write parameter edit box.

  > [!NOTE]
  > This command will only be available when there is a write parameter.

#### Visual Overview: Adding a 'Refresh' and/or a 'Sort' button to a table control \[ID_33346\]

When using a shape of type *ParameterControls* to visualize a table in a Visio drawing, you can now add a *Refresh* button and/or a *Sort* button to that shape.

Example of how to add both a *Refresh* button and a *Sort* button:

1. Create three shapes and group them:

   - the first shape will contain the table,
   - the second shape will contain the *Refresh* button, and
   - the third shape will contain the *Sort* button.

1. Add the following shape data field to the shape that has to contain the table:

   | Shape data field      | Value |
   |-------------------------|-------|
   | ParameterControlOptions | Table |

1. Add the following shape data field to the shape that has to contain the Refresh button:

   | Shape data field      | Value   |
   |-------------------------|---------|
   | ParameterControlOptions | Refresh |

1. Add the following shape data field to the shape that has to contain the Sort button:

   | Shape data field      | Value |
   |-------------------------|-------|
   | ParameterControlOptions | Sort  |

1. Add the following shape data fields to the group:

   | Shape data field | Value                      |
   |--------------------|----------------------------|
   | Element            | Element ID or element name |
   | ParameterControl   | ID of the table parameter  |

> [!NOTE]
> The *Refresh* button and the *Sort* button will only be displayed when necessary.

#### DataMiner Cube: Independent client updates \[ID_33360\]

When you connect DataMiner Cube to a DataMiner Agent with main release version 10.2.0 CU3 (or newer) or feature release version 10.2.6 (or newer), from now on, it will automatically update to the most recent version. This will allow you to use the latest Cube features as soon as they are released without having to wait for a DMA upgrade.

##### Client configuration

If you do not want to wait for the next automatic Cube update, in the start window of the Cube desktop app, click the cogwheel icon in the bottom-right corner, and select *Check for updates*. If a new Cube version is available, it will be downloaded. When the download has finished, a *Restart now* button will appear. Click it to start using the new version.

Two update tracks are available. Click the cogwheel icon in the bottom-right corner, and select *Settings*. If you open the Cube update track setting, you can select one of the following tracks:

| Track                     | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| Release                   | Use the latest released DataMiner Cube version, so you can enjoy all the latest and greatest features. |
| Release (delayed 2 weeks) | Wait to use the latest released DataMiner Cube version until 2 weeks after the release date.           |

If you want to use a specific Cube version to connect to a particular agent or cluster, then right-click an agent or cluster in the start window, and select a specific Cube version.

##### Server configuration

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions*, and select one of the following Cube update modes:

- Allow automatic updates
- Force the matching release version (i.e. force users to always use the Cube version that was shipped with the DMA upgrade package)
- Force a specific version (i.e. force users to always use a particular Cube version)

By default, the setting chosen here will apply to all agents in the DMS, including Failover setups. However, it is possible (but not recommended) to configure the Cube update mode per agent.

### DMS Automation

#### Engine object: TriggeredByName property added \[ID_33122\]

A TriggeredByName property has been added to the Engine object. This property of type string will contain the full name of the user who started the Automation script (e.g. “John Doe”).

When an Automation script is triggered by the scheduler, a correlation rule or a redundancy group, the TriggeredByName property will contain one of the following strings:

- “Scheduled task \<name task>”
- “Correlation-rule \<name rule>”
- “Redundancy”

### DMS web apps

#### Monitoring app now also takes into account Param.Message tags \[ID_33162\]

In a protocol.xml file, for every write parameter, you can specify a message to be displayed when users change that parameter on the UI.

Up to now, this *Param.Message* tag was only taken into account by DataMiner Cube. From now on, the Monitoring app will also take it into account.

#### DataMiner Application Framework now requires the 'Low-code Apps' license \[ID_33208\]

As the “Low-code Apps” license is required to use the DataMiner Application Framework, you will now no longer have access to the framework if you do not have this license.

#### DataMiner Application Framework: Tooltips on sidebar of root page \[ID_33275\]

When you click the apps button in the top-left corner of the root page and then hover over an app in the app list, a tooltip will now show the name of that app.

### DMS Service & Resource Management

#### Subscribing to ResourceUsageStatusEvents for specific resources \[ID_32979\]

From now on, it is possible to only receive ResourceUsageEventMessages for a specific resource. Using ResourceUsageStatusEventExposers, you can now filter by ResourceId.

### DMS tools

#### Standalone Elasticsearch Cluster Installer: New RepoPath setting \[ID_33055\]

The optional RepoPath configuration setting (which corresponds with the Path.Repo Elasticsearch setting) allows you to define a snapshot path. For a cluster, this should be a shared file location. If this setting is not filled in, it will be commented out in the Elasticsearch configuration.

When you run the installer with the “generate” option (run-stand-alone -g), the sample configuration will now include a \<RepoPath> element and a \<DiscoveryHosts> element. See the following example:

```xml
<ElasticConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ElasticYamlSettings>
    <ClusterName>DMS</ClusterName>
    <NodeName>DataMinerBestMiner</NodeName>
    <DataPath>C:\ProgramData\Elasticsearch</DataPath>
    <RepoPath>C:\ProgramData\RepoPath</RepoPath>
    <NetworkHost>0.0.0.0</NetworkHost>
    <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
    <DiscoveryHosts>
      <string>"IP1"</string>
      <string>"IP2"</string>
    </DiscoveryHosts>
    <MinimumMasterNodes>1</MinimumMasterNodes>
    <MasterNode>true</MasterNode>
    <DataNode>true</DataNode>
  </ElasticYamlSettings>
  <InstallerDependenciesDirectory>unspecified</InstallerDependenciesDirectory>
  <ElasticTargetDirectory>C:\Program Files\Elasticsearch</ElasticTargetDirectory>
</ElasticConfiguration>
```

## Changes

### Enhancements

#### Security enhancements \[ID_33069\] \[ID_33078\] \[ID_33218\]

A number of security enhancements have been made.

#### DataMiner Taskbar Utility: Deprecated launch options for System Display and Cube removed \[ID_32877\]

In the DataMiner Taskbar Utility, the following options have been removed:

- Launching System Display by double-clicking while pressing the SHIFT key.
- Opening the locally installed DataMiner Cube in Microsoft Internet Explorer by double-clicking.

> [!NOTE]
> The following option has been kept:
>
> - Opening Windows file explorer in the C:\\Skyline DataMiner\\ folder by double-clicking while pressing the CTRL key.

#### Enhanced performance when starting up elements \[ID_33023\]

Because of a number of enhancements, overall performance has increased when starting up elements, especially elements containing large amounts of data.

#### DataMiner Cube & legacy Reporter app: Alarm state change graphs now differentiate between masked state and unknown state \[ID_33082\]

From now on, the alarm state change graphs (pie chart and time line) in the legacy Reporter app and the alarm state change pie chart on the REPORTS page of an element card in Cube will differentiate between masked state and unknown state.

Also, in the legacy Reporter app, the default colors have now been aligned with the default DataMiner alarm colors.

#### Enhancements with regard to Automation scripts \[ID_33129\] \[ID_33226\]

A number of enhancements have been made with regard to Automation scripts.

- When a script is launched, from now on, only the parameters/dummies with missing values will be shown. Automatically filled in values will no longer be shown.
- When script input is filled in with feed data, users will no longer be asked to change that input manually.
- Script input (parameters/dummies) linked to a feed is now filled in at the moment a script action is triggered. Subsequent changes in the feed will have no effect.
- In the application framework, the option to mark specific script parameters and dummies as required has been removed.
- When, in the Dashboards app, users mark a script parameter as required, they no longer need to fill in a value.
- From now on, a page load event will only trigger after the application page has been fully initialized. This will ensure that, when launching script actions with input linked to feeds, those feeds have been initialized.

#### Visual Overview: Enhanced performance when creating element shapes \[ID_33140\]

Because of a number of enhancements, overall performance has increased when creating element shapes.

#### Service & Resource Management: Enhanced logging \[ID_33183\]

Up to now, when the SRM log files were set to “No logging”, no information would be logged if e.g. a Reservation event had failed. All ResourceManager, ResourceManagerAutomation and FunctionManager logging has now been re-evaluated, and the log settings have been optimized. All critical issues occurring in those modules will now be logged.

#### Profile instance list for PA service definition node now also contains child instances \[ID_33187\]

When you configure a service definition node in the Services app, a list of profile instances is shown for the selected profile definition. For service definitions of type "Skyline Process Automation" and "Custom Process Automation", this list will now also contain instances for child definitions of the configured profile definition.

#### SLDMS process is now large address aware \[ID_33234\]

SLDMS, which is a 32-bit process, will now be started with the /LARGEADDRESSAWARE flag. This way, it will be able to access up to 4GB of memory.

#### Enhanced performance when processing a large number of objects with links to other objects \[ID_33271\]

Because of a number of enhancements, overall performance has increased when processing (e.g. exporting) a large number of objects with links to other objects.

#### IPC channel port names will now always be unique \[ID_33274\]

IPC channel port names will now always be unique.

#### Anomaly detection: Enhanced performance when generating suggestion events and alarms \[ID_33283\]

Because of a number of enhancements, overall performance has increased when generating anomaly detection suggestion events and alarms.

#### DataMiner Cube - System Center: 'Automatic incident tracking' feature will now be enabled by default \[ID_33286\]

In *System Center \> System settings \> Analytics config*, the *Automatic incident tracking* feature will now be enabled by default.

- If you upgrade from a DataMiner version older than 10.0.11, a new *Automatic incident tracking* section will be added to the *Analytics config* tab, and its *Enabled* setting will by default be set to “True”.
- If you upgrade from DataMiner version 10.0.11 until 10.1.11, the *Automatic incident tracking* section will now by default have its *Enabled* setting set to “True”. Up to now, it would by default be set to “False”.
- If you upgrade from DataMiner version 10.1.12 or newer, the *Automatic incident tracking* section, of which the *Enabled* setting was by default already set to “True”, will now even be set to “True” when it had been manually set to “False” earlier.

> [!NOTE]
> After the upgrade, all settings related to *Automatic incident tracking* will be reset to their default values. Any manual change made to any of these settings prior to the upgrade will be lost.

### Fixes

#### Alarm templates: Incorrect calculation of smart baselines \[ID_31601\]

In some cases, smart baselines would be calculated incorrectly, especially when the “Skip the last X hours in the configured trend window” and “Handle weekend days separately” options were enabled.

#### QActionHelper DLL file could incorrectly be loaded twice \[ID_32647\]

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

#### Elasticsearch: TTL settings would not be applied correctly \[ID_32913\]

In some cases, TTL settings defined in an Elasticsearch database would not be applied correctly. As a result, certain data (e.g. profile instance data) would not get properly cleaned up.

#### DataMiner Cube - ListView component: Time zone would not be taken into account when setting the default time range interval \[ID_33011\]

When the client and the server did not have the same time zone, in some cases, the default time range interval of a ListView component could be set incorrectly. As a result, filtering by date/time could yield incorrect results.

From now on, the default time range of a ListView component will take into account the DataMiner time in UTC and the server time zone.

#### Hysteresis timer would incorrectly restart when a base line got updated \[ID_33015\]

When a base line got updated while a hysteresis timer was running on a table cell, in some cases, that timer would incorrectly restart.

#### Dashboards app - Node edge graph component: Node would not get positioned correctly by default \[ID_33068\]

Up to now, when the edges were unidirectional, the nodes would not get positioned correctly by default.

#### DataMiner Cube - Resources app: No update notifications would get broadcast within a client session when a resource was deleted from the cache \[ID_33070\]

When a resource was deleted from the cache of a Cube client, in some cases, no update notifications would get broadcast within the same client session.

#### Ticketing app: Problem when using the filter box \[ID_33079\]

When you entered a search string in the filter box, all tickets would incorrectly be returned.

#### DataMiner Cube - Automation: Problem when validating an Automation script \[ID_33084\]

When, in the Automation app, you validated an Automation script that either contained an empty line in the DLL references or had a DLL reference removed, in some cases, an “Empty path name is not legal” error could be thrown.

#### DataMiner Cube: REPORTS page of a masked element would incorrectly indicate that the element was in alarm instead of masked \[ID_33087\]

When you masked an alarm as well as its associated element, in DataMiner Cube, the REPORTS page of the element in question would incorrectly indicate that the element was in alarm instead of masked.

#### Business Intelligence: Problem with SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started \[ID_33098\]

In some cases, an error could occur in SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started.

Also, additional logging has been added to help debug and track SLA issues.

#### SLElement: Display key cache would not get properly cleaned up when a row was deleted \[ID_33114\]

In some cases, the display key cache of SLElement would not get properly cleaned up when a row was deleted. This could cause memory leaks when a protocol added or removed a large amount of rows.

#### DataMiner Cube - Visual Overview: Bitmap images would be missing when opening a cached version of a VDX file \[ID_33116\]

When a Visio file of type VDX contained bitmap images, in some cases, those images would be missing when you opened a cached version of that file.

#### Application Framework: Two button components would incorrectly be displayed when the 'ReportsAndDashboardsButton' soft-launch flag was enabled \[ID_33124\]

In the Application framework, in some cases, two button component would incorrectly be displayed when the “ReportsAndDashboardsButton” soft-launch flag was enabled.

#### DataMiner Agent would not start up when the computer name contained special characters \[ID_33137\]

In some cases, a DataMiner Agent would fail to start up when the computer name contained special characters (e.g. “ü”).

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated \[ID_33153\]

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### Dashboards app - GQI: Problem when a feed used by a query was changed while the query table was being sorted \[ID_33168\]

When a feed used by a GQI query was changed while the query table was being sorted, in some cases, the UI could become unresponsive.

#### Web apps - GQI: Column references could not be created for columns of which the name contained underscore characters \[ID_33169\]

In some cases, column references could not be created for columns of which the name contained underscore characters.

#### Web apps - GQI: Problem when retrieving ticket fields of type 'drop-down list' \[ID_33177\]

When ticket fields of type “drop-down list” were retrieved using a GQI query, in some cases, those fields would incorrectly not contain any values.

#### SLPort would incorrectly split WebSocket messages larger than 65kB \[ID_33182\]

Up to now, when SLPort received a WebSocket message larger than the WebSocket buffer (i.e. 65 kB), it would incorrectly split that message in multiple chunks before passing it to the protocol.

#### Visual Overview: Problems with SelectedServiceDefinition session variable and with commands for ServiceManager component \[ID_33187\]

The following issues could occur in Visual Overview:

- When a service definition was selected, it could occur that the *SelectedServiceDefinition* session variable was not updated.
- When the *Commands* shape data field was used, it could occur that setting commands on page or card level was not possible.

#### DataMiner Cube - Visual Overview: Spectrum shape would incorrectly show a grid instead of text \[ID_33192\]

When a shape was linked to a spectrum parameter with an ID between 50,000 and 60,000, in some cases, the shape would incorrectly show a grid instead of text.

#### Alarm Console - Automatic incident tracking: Alarms removed from a manually created incident would be grouped incorrectly \[ID_33195\]

When you removed an alarm from a manually created incident (alarm group), in some cases, the removed alarm would be grouped incorrectly.

#### SNMP polling: Group with multiple tables of which some had the 'partialSNMP' option enabled would get re-polled indefinitely \[ID_33197\]

When a group that contained multiple tables of which some had the partialSNMP option enabled was polled, in some cases, that same group would incorrectly get re-polled indefinitely.

#### Alarm templates: Problem with anomaly detection alarms [ID_33216]

<!-- MR 10.2.0 [CU16] - FR 10.2.6 -->

When you created an element with an alarm template in which anomaly detection alarms were configured for table parameters, in some cases, none of the enabled types of change points would trigger an alarm.

#### DataMiner Cube: Problem when logging in \[ID_32233\]

When you logged in to DataMiner Cube, in some cases, the loading process would no longer be shown. Also, a “Timeout while retrieving connection settings” error could be thrown.

#### Port 0 would incorrectly be used for serial communication when a dynamic IP parameter did not contain an IP port \[ID_33235\]

When a dynamic IP parameter was set to a value that contained only an IP address instead of an IP address and a IP port, then port 0 would incorrectly be used for serial communication.

From now on, when no IP port is specified, the last port set will be used. And if no port has been set yet, then the port configured in the element wizard will be used.

#### Application framework: Pages could not be loaded when previewing a draft version of an application that had not yet been published \[ID_33241\]

When previewing a draft version of an application, in some cases, pages could not be loaded when there was no published version yet.

#### Application framework: 'This panel' option not available when configuring a 'close a panel' action \[ID_33243\]

When configuring a “close a panel” action, in some cases, the “This panel” option would incorrectly not be available. From now on, this option will always be available and selected by default.

#### Application framework: New page and panel created automatically when editing an unpublished application \[ID_33251\]

When you edited an unpublished application, in some cases, a new page and panel would incorrectly be created automatically.

#### Application framework: Application would incorrectly open in edit mode after logging in \[ID_33254\]

When you logged out of an application and then logged back in again, in some cases, the application would incorrectly switch to edit mode.

#### PDF reports generated from a dashboard could no longer be uploaded to a shared folder \[ID_33256\]

When a PDF report was generated from a dashboard, in some cases, it would not be possible to upload that report to a shared folder.

#### Application framework: Table row action buttons would incorrectly always be displayed on the first column of a table \[ID_33258\]

Up to now, table row action buttons would incorrectly always be displayed on the first column of a table. As a result, those buttons would disappear when e.g. a filter was applied that caused the first column to be hidden. From now on, table row action buttons will instead always be displayed on the first visible column of a table.

#### SLNetTypes protocol buffer contract was no longer compatible with DataMiner versions older than version 10.2.3 \[ID_33260\]

As from DataMiner version 10.2.3, the SLNetTypes protocol buffer contract was no longer compatible with DataMiner versions older than version 10.2.3. This issue has now been fixed. The SLNetTypes protocol buffer contract is now again compatible with DataMiner versions older than version 10.2.3.

> [!NOTE]
> As a result of this change, the SLNetTypes protocol buffer contract in this DataMiner 10.2.6 version is not compatible with DataMiner versions 10.2.3, 10.2.4 and 10.2.5.

#### Application framework: Action editor would incorrectly update the application each time it detected a change \[ID_33261\]

Up to now, the action editor would incorrectly update the application each time it detected a change. From now on, an application will only be updated when its configuration changes.

#### Application framework: An 'http://' prefix would incorrectly be added to any URL that did not start with 'http://' \[ID_33262\]

Up to now, the application framework would incorrectly add an “http://” prefix to any URL that did not start with “http://”. From now on, all URLs will be validated first. Only if the URL is invalid (e.g. “skyline.be”) will an “http://” prefix be added.

#### Dashboards: Not possible to share dashboards that contained query components of which the 'Update data' option was enabled \[ID_33267\]

Up to now, it would not be possible for users to share dashboards that contained GQI components of which the *Update data* option was enabled.

#### Replicated main DVE element would incorrectly execute a sequence twice \[ID_33270\]

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a \<Sequence>, then that sequence would incorrectly be executed twice on the replicated element.

#### DataMiner Cube - Alarm templates: Anomaly detection alarms would incorrectly disappear after a DataMiner restart \[ID_33278\]

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters.

Up to now, these anomaly detection alarms would incorrectly disappear from the Alarm Console after a DataMiner restart.

#### Problem when trying to retrieve base parameter values after changing the production version of a protocol based on a base protocol \[ID_33288\]

After changing the production version of a protocol based on a so-called base protocol, it would no longer be possible to retrieve values from any of the base parameters (i.e. parameters of the base protocol).

#### Application framework: Problem when switching between feeds linked to Automation script input \[ID_33290\]

When, in the application framework, you add an action that launches an Automation script, you can link the script parameters to feeds. Up to now, when those feeds each had a property with the same name (e.g. a property called “Name”), the action would incorrectly not get updated when you switched from one feed to another.

#### Application framework: Minor issues fixed \[ID_33291\]

A number of minor issues have been fixed in the DataMiner Application Framework.

#### BREAKING CHANGE: Problem when filtering a table with a foreign key relation to a remote table using a filter that contained a value from the remote table \[ID_33294\]

When a table with a foreign key relation to a remote table was filtered using a filter that contained a value from the remote table, up to now, all rows would incorrectly be returned when the remote table was empty. From now on, when the remote table is empty, no rows will be returned.

#### DataMiner Cube - Trending: Problem when zooming out on a trend graph \[ID_33298\]

When you zoomed out on a trend graph with a large number of data points, in some cases, the UI would become unresponsive.

#### DataMiner Cube desktop app: Problem when creating a new group in the start window \[ID_33300\]

In some rare cases, an error could occur when you created a new group in the start window of the DataMiner Cube desktop app.

Also, the name of a group could get lost when you deleted the first agent/cluster in that group.

#### Application framework: A request to update the application would incorrectly be sent when you opened an action that launches an Automation script \[ID_33302\]

When, in the application framework, you opened an action that launches an Automation script, up to now, a request to update the application would incorrectly be sent as soon as the script was loaded.

#### Problem with SLDataMiner when a DMA started up while another DMA in the DMS was registering the SLAs \[ID_33303\]

When a DataMiner Agent started up while another DataMiner Agent in the DMS was registering the SLAs, in some cases, an error could occur in the SLDataMiner process.

#### Filtering issue when requesting bookings from 2 different time ranges \[ID_33312\]

When bookings were requested from the server, and a filter was used to first retrieve bookings from the distant future and then from the near future, it could occur that the latter could not be retrieved because of a problem with the filtering.

#### CSLCloudBridge library would incorrectly not take into account the connection timeout specified in SLCloud.xml \[ID_33322\]

Up to now, the CSLCloudBridge library would incorrectly not take into account the connection timeout specified in the SLCloud.xml file. In some cases, this could lead to run-time errors in the MessageBrokerReconnectThread.

The connection timeout specified in SLCloud.xml is the maximum time it can take to set up a connection with NATS (in milliseconds). Minimum value is 1000 ms, default value is 5000 ms.

```xml
<SLCloud>
  ...
  <ConnectTimeout>5000</ConnectTimeout>
  ...
</SLCloud>
```

#### Application framework: Table rows sorted incorrect after refetching the table data \[ID_33323\]

When a table component refetched the table data, in some cases, the table rows would not be sorted correctly.

#### ResourceManager module would fail to initialize on systems with a MySQL database \[ID_33327\]

On systems with a MySQL database, the ResourceManager module would fail to initialize.

#### Application framework: Action chains in which a post action needed data input would no longer work after a refresh of the application \[ID_33333\]

When you refreshed an application, in some cases, action chains in which a post action needed data input would no longer work.

#### Web apps - Data table component: Query placeholders would incorrectly be displayed as values when the GQI query did not return any rows \[ID_33372\]

When a GQI query did not return any rows, the data table component would incorrectly display the query placeholders as values. From now on, when a GQI query does not return any rows, the data table component will display a message, saying that no data is available.

#### DataMiner Cube - Alarm Console: Menu command to copy cell value missing \[ID_33378\]

When, in the Alarm Console, you right-click an alarm, you can copy the value in the cell you right-clicked by selecting *Copy \> cell “\<value>”*. In some cases, this *Copy \> cell “\<value>”* command would incorrectly be missing.

#### Automatic Incident Tracking: Clearable base alarms of an incident were cleared when the incident was cleared \[ID_33481\]

When an incident (i.e. alarm group) was cleared, in some cases, its clearable base alarms would incorrectly be cleared as well when the AutoClear option was disabled.
