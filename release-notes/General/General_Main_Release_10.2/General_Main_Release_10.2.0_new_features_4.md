---
uid: General_Main_Release_10.2.0_new_features_4
---

# General Main Release 10.2.0 - New features (part 4)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS Cube

#### Launching DataMiner Cube on a specific host using the cube:// protocol \[ID_28160\]

Using the cube:// protocol, it is now possible to launch a DataMiner Cube on a specific host. All existing URL arguments are supported.

Examples:

```txt
cube://mydma?element=MyElement
cube://10.11.12.13?view=12
```

#### Visual overview: Page-level execution of Automation scripts & new NodeDoubleClicked event \[ID_28185\]

On a Visio page, you can now configure to have Automation scripts executed automatically using a page-level data item of type *Execute*.

See the example below. You can use the keywords *Trigger* or *SetTrigger*, which can be set to either “ValueChanged” or “Event”.

Example:

```txt
Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...| ParameterName1=[var:myVar];ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|ToolTip|Options|Trigger=ValueChanged
```

##### Reserved prefixes can now mark each of the syntax components

In the syntax to be used in Automation script shapes as well as page-level Automation script triggers, each component can now be marked by a prefix. That way, you will no longer have to define empty components in case there are no dummies, no memory files, etc.

List of reserved prefixes:

- “Parameters:”
- “Dummies:”
- “MemoryFiles:”
- “Options:”
- “Tooltip:”

Example of syntax that can now be used in a shape data item of type *Execute*:

```txt
Script:<myScript>|Tooltip:<myTooltip>|Parameters:paramA=<myParam>|Options:NoConfirmation
```

> [!NOTE]
>
> - If you choose to use prefixes to mark syntax components, you must use them for every component.
> - When you use prefixes to mark syntax components, the components can be added in whatever order you choose.

##### New NodeDoubleClicked event

In an \[Event:\] placeholder, you can now add a new event named *NodeDoubleClicked*, followed by the argument *ID* or *Label*.

This event will trigger when you double-click a service definition node in an embedded Service Manager component. The event placeholder will then be replaced by the value of the specified argument.

Example:

```txt
[event:NodeDoubleClicked,ID]
```

##### Use case

Using the new features described above, it is possible to configure that when a user clicks a service definition node in an embedded Service Manager component, an Automation script is executed with e.g. the node ID as a parameter.

To configure this behavior, add a page-level data item of type *Execute*, and set its value to e.g. the following:

```txt
Script:<myScript>|Parameters:IDParam=[event:NodeDoubleClicked,ID]|Options:<possibleOptions>|Trigger=Event
```

#### Visual Overview: A shape linked to an alarm can now display the parameter key \[ID_28212\]

Using a data field of type “Info” set to the value “PARAMETER KEY”, a shape linked to an alarm can now be made to display the parameter key of the alarm in question.

#### System Center - Database: Option to offload database data to a file \[ID_28226\]

In the *Database* section of *System Center*, you can now also opt to offload database data to a file instead of a database.

#### Visual Overview: Group-level shape data fields of type 'ChildrenSort' now support placeholders \[ID_28289\]

In a group-level shape data field of type *ChildrenSort*, it is now possible to use placeholders.

This will allow you to dynamically specify how the different child item shapes should be sorted using placeholders such as “\[var:xxx\]” and “\[param:xxx\]”.

#### DataMiner Cube start window: Grouping, rearranging and filtering tiles \[ID_28346\]

In the DataMiner Cube start window, tiles representing DataMiner Systems or DataMiner Agents can now be grouped, rearranged and filtered.

- To create a new group, drag a tile out of its current group.
- To name or rename a group, click above the group and enter the (new) name.
- To move a tile to another position (or another group), drag it to its new position.
- To filter the tiles, hover over the looking glass and enter a search string in the search box. Alternatively, you can also start typing a search string without going to the search box.

    > [!NOTE]
    > When a search does not yield any results, you can click the plus icon or press ENTER to add the hostname or IP address you were looking for.

> [!NOTE]
>
> - The start window now has keyboard support. Use the arrow keys to move from one tile to the next, and press ENTER to launch.
> - The start window can now be resized. When you resize and/or reposition the window, its new size and position will be saved.

#### Visual Overview: Support for saving page and card variables \[ID_28434\]

It is now possible to have page variables and card variables saved across sessions.

To do so, place the following prefix before the variable name:

`__saved_`

The variable is then saved in a separate .dat file located in the following folder on the client machine: *C:\\Users\\{Username}\\AppData\\Roaming\\Skyline\\DataMiner*. When a variable is saved, if a user reopens a card with that variable, the variable will be set to the last saved value.

#### Visual Overview - ChildrenFilter: Using a regular expression to filter by name \[ID_28445\]

In a shape data field of type ChildrenFilter, it is now possible to filter by service name, view name or child element name.

To do so, in the ChildrenFilter data field of the child shape, add “Name=” following by a regular expression:

| Shape data field | Value           |
|------------------|-----------------|
| ChildrenFilter   | Name=\<myRegex> |

If you add this type of filter to a template shape, only objects of which the name matches the regular expression will use that particular template shape.

#### Service & Resource Management - Services app: Visualization and configuration of the node interfaces of service profile definitions and service profile instances \[ID_28508\]

In the *Profiles* tab of the *Services* app, it is now also possible to visualize and fully configure the node interfaces of service profile definitions and service profile instances.

Also, it is now possible to select a profile instance for every node interface of a service profile instance node.

#### Visual Overview: TableRowFilter option of ParameterControlOptions data item now supports FullFilter syntax \[ID_28531\]

When defining a table control in Visual Overview, it is now possible to use FullFilter syntax when configuring the *TableRowFilter* option in the *ParameterControlOptions* data item.

Example:

| Shape data field        | Value                                            |
|-------------------------|--------------------------------------------------|
| Element                 | MyTableElement                                   |
| ParameterControl        | 1000                                             |
| ParameterControlOptions | TableRowFilter:FULLFILTER=(PK == 0) OR (DK == 1) |

#### Service & Resource Management - Services app: Existing connections between node interfaces can now be edited on the service diagram using drag and drop \[ID_28597\]

In the service diagram, it is now possible to change the end points of connections between service definition node interfaces using drag and drop.

1. Select an existing connection. Its “from” and “to” interfaces will be highlighted.
2. Click the endpoint you want to change and drag it onto another endpoint while keeping the mouse button pressed.
3. Release the mouse button. The connection will now have changed. Its source point will be the same as before, but its endpoint will have changed.

#### DataMiner Cube start window: Opening a Cube instance without closing the start window \[ID_28608\]

It is now possible to connect to a DMA without closing the start window. To do so, in the start window, click a tile while holding the CTRL button.

This will allow you to open multiple instances of DataMiner Cube, each connected to a different DMA.

> [!NOTE]
> If you press ENTER while holding the CTRL button, a Cube instance will open and connect to the DMA specified in the currently selected tile.

#### DataMiner Cube: Option to return to the start window after logging out \[ID_28648\]

When you log out of DataMiner Cube, the login window appears. In that window, you can now click the *Back to start window* button to return to the DataMiner Cube start window.

#### Profiles app: Failsafe mechanism added to prevent situations where updates made by one user get overwritten by updates made by another user \[ID_28651\] \[ID_30057\]

The Profiles app now contains a failsafe mechanism to prevent possible situations where updates made by one user get overwritten by updates made simultaneously by another user.

#### DataMiner Cube - Alarm Console: Translations added for two new reasons mentioned in Value column of group alarms generated by Automatic incident tracking \[ID_28676\]

When automatic incident tracking is activated, active alarms that are related to the same incident will automatically be grouped into a new alarm, and the Value column of such an alarm will show the reason why the alarms underneath it were grouped.

Translations have now been added for two new reasons:

- View group
- Custom property group (which will be formatted as “\<propertyName> group: \<value>”)

#### Visual Overview: ListView component can now be used to list resources \[ID_28723\] \[ID_30998\]

The ListView component can now also be used to list resources. To do so, add a shape data field of type “Source” and set its value to “Resources”.

| Shape data field | Value |
|--|--|
| Component | ListView |
| Source | Resources |
| ComponentOptions | List of options, separated by pipe characters. For an overview of all possible component options, see [Component options](xref:Creating_a_list_view#component-options). |
| Columns | The list of columns that have to be displayed. Preferably, this should be configured by specifying the name of a saved column configuration, e.g. MyColumnConfig.<br> Saving a column configuration is possible via the right-click menu of the list header in DataMiner Cube. This right-click menu also allows you to load a column configuration.<br> If you do not specify this shape data field or leave it empty, all columns will be displayed. |
| Filter | Examples:<br> - Resource.Name\[string\]== 'Encoder'<br> - Resource.Name contains 'res'<br> - Resource.Name notContains 'res'<br> - Resource.ID\[Guid\] == fad6a6dd-ca3a-4b6f-9ca7-b68fd2071786<br> - Resource.MainDVEDmaID == 113<br> - Resource.PoolGUIDs contains<br>0fb47f51-ad81-47f2-9e69-3d9477bdc961<br> - Resource.MaxConcurrency != 1<br> - Resource.PropertiesDict.Location\[string\] == '3'<br> - Resource.Name\[string\] notContains 'RS' AND Resource.Name\[string\] notContains 'RT' AND Resource.Name\[string\] notContains 'ExposeFlow' <br>For more information on list view filters, see [List view filters](xref:Creating_a_list_view#list-view-filters). |

> [!NOTE]
> The IDOfSelection session variable contains a list of the IDs or GUIDs of the selected items, separated by pipe characters.

#### EPM: Chain grouping & automatic selection of single filter values \[ID_28751\]\[ID_28834\]\[ID_28846\]

In DataMiner Cube, EPM chains with the same value in the protocol’s Chain@groupingName element attribute (see example below) will now be grouped under that value in the EPM manager card (side panel and tabs) and in the chains selection box located in the topology sidebar.

Also, it is now possible to specify one filter value per chain that should be selected by default in filter boxes that contain only that specific value.

##### Example of a Protocol.Chains.Chain element with a group name and a default filter value

See the following example. The chain named “MyChain” will be part of the group named “MyChainGroup”, and if the filter named “MyField” only has one value, it will automatically be selected when you open the chain in the CPE manager or the topology tab in the sidebar.

```xml
<Protocol>
  <Chains>
    <Chain name="MyChain" defaultSelectionField="MyField" groupingName="MyChainGroup">
      ...
    </Chain>
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - Each chain can only be part of a single chain group.
> - Chains that are not part of a group will be displayed as top-level tabs (on the same level as the group tabs).

#### Information event generated when a context menu of a table is used \[ID_28753\]

When, in DataMiner Cube, you open a context menu of a table and select an option from it, from now on, an information event will be generated similar to the one that is generated when you set a parameter.

This information event will contain the following data:

- **Parameter description**: The full display name of the context menu parameter. Format: *\<TableName>\_ContextMenu*

- **Parameter value**: A value in the following format:

  `Set by <user> to <command display value>`

  If there are dependency values, the value will have the following format:

  `Set by <user> to <command display value>: “<dependency 1>”; “<dependency 2>”`

#### Settings window: 'Surveyor' section renamed to 'Sidebar' & New 'Launch EPM card on filter selection' setting added \[ID_28788\]

In the user settings tab of the *Settings* window, the *Surveyor* section has been renamed to *Sidebar*.

Also, in that section, the existing Surveyor settings have now been grouped under the title “Surveyor”, and a new *Launch EPM card on filter selection* setting has been added under the title “Topology”. When you enable this new setting, an EPM card will automatically be launched after selecting an item in a topology tab filter.

#### DataMiner Cube will now use Chromium to handle SAML authentication \[ID_28922\]

In order to support a wider range of identity providers (e.g. Azure AD), DataMiner Cube will now use Chromium instead of Internet Explorer when handling SAML authentication.

> [!NOTE]
> DataMiner Cube clients will now automatically download the CefSharp package from the DataMiner Agent they connect to.

#### Alarm Console: New option to allow a history tab to show alarms associated with an enhanced service deleted in the selected time frame \[ID_28942\]

Up to now, when you created a history tab with a service filter, it was only possible to select one of the active enhanced services. Now, it is also possible to select one of the enhanced services that has been deleted in the selected time frame (e.g. “last hour”).

When, in the filter section, you selected “Service” and you want to be able to select an enhanced service that has been deleted in the selected time frame, then click the *Load deleted services* option, and select the deleted service from the list. That way, you will be able to create a history tab that lists the alarms associated with an enhanced service that has been deleted in the selected time frame.

#### Enhanced table export \[ID_28952\]

The table export mechanism has been reworked.

Also, in case of paged tables, it is now possible to indicate whether you want to export only the current page or the entire table.

#### New Surveyor setting: Collapse DVE elements beneath their main element \[ID_29021\]

The new Surveyor setting “Collapse DVE elements beneath their main element” now allows you to specify how DVE child elements are displayed.

By default, this setting is disabled, and DVE child elements are displayed in the same way as other elements.

- If you set this to “All DVEs”, DVE child elements will be displayed on the level below the parent elements in the tree structure, so that you can collapse and expand the list of child elements.
- If you set this to “Only function DVEs”, this will only happen for function DVEs.

#### Resources app: Enhanced UI \[ID_29086\]

The UI of the Resources app has had a complete overhaul. Look and feel are now in line with all other SRM-related apps.

#### Logging of important user actions \[ID_29139\]

From now on, the following important user actions will be logged in the SLClient.txt log file:

- Connect
- Disconnect
- Cube loaded
- Card opened
- Card closed
- Visio file loaded
- Alarm tab created in Alarm Console
- Trend graph opened

#### Services app: Duplicating service profile definitions and service profile instances \[ID_29262\]

In the *Profiles* tab of the *Services* app, it is now possible to duplicate service profile definitions or service profile instances.

#### Visual Overview: AlarmSettings tag of MaintenanceSettings.xml has new elementTimeoutMode attribute \[ID_29498\]

Next to the serviceTimeoutMode and viewTimeoutMode attributes, the AlarmSettings tag of the *MaintenanceSettings.xml* file now also has an elementTimeoutMode attribute.

Similar to the other two attributes, it can be set to one of the following values.

| Value | Description |
|--|--|
| displayTimeout | Shapes linked to elements will only show the timeout color. The current alarm color will not be shown. (Default setting.) |
| displayBoth | Shapes linked to elements will show both the current alarm color and the timeout color. The timeout color will be shown as a hatch pattern. |

#### Visual Overview: Prevent a child shape from inheriting the service context of its parent shape \[ID_29503\]

By default, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

If you want to prevent this from happening, from now on, you can add the AllowInheritance option to the child shape and set its value to false.

#### Profiles app: New profile instance update errors \[ID_29546\]

When a ProfileInstance is updated while it is being used by one or more bookings, the following additional errors can now be returned.

When a ProfileInstance is updated without quarantine being forced (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When a ProfileInstance is updated with quarantine being forced (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

#### Profiles app: Profile parameters can now have settings configured \[ID_29580\]

It is now possible to configure a profile parameter to be hidden in scripts using the profile, with a new *Hide from scripts* checkbox for profile definitions and profile instances in the Profiles app.

#### EPM: Hiding chains and chain fields based on parameter values \[ID_29640\]\[ID_29656\]

DataMiner Cube now supports hiding specific chains (normal chains and search chains) and chain fields in an EPM topology based on parameter values, in the sidebar as well as in EPM Manager cards.

Below, you can find examples of how to configure conditional visibility in an element protocol.

##### Chain visibility

Example:

```xml
<Chain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Chain field visibility

Example:

```xml
<Chain>
  <Field>
    <Display>
      <Selection>
        <Visibility default=”false”>
          <Standalone pid=”18”>
            <Value>1</Value>
            <Value>2</Value>
          </Standalone>
        </Visibility>
      </Selection>
    </Display>
  </Field>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Search chain visibility

Example:

```xml
<SearchChain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</SearchChain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

#### Visual Overview: New icon added to Icons stencils \[ID_29751\]

The following icon has been added to the Icons stencil:

- TX

#### Logging: New log file 'Resource Manager Storage' \[ID_29776\]

The Logging module now also allows you to access the SLResourceManagerStorage.txt log file.

#### New spectrum recording playback controls \[ID_29807\]\[ID_29926\] \[ID_30218\]

While a spectrum trace recording is playing, new controls are now available at the bottom of the display section:

- A slider control, which allows you to navigate to a specific point in the recording.
- Controls to go forward and backward in the recording, trace by trace.
- A pause/play toggle control.
- A fast forward button. The current playback speed is displayed next to this button. You can click the fast forward button again to increase the playback speed further.

While a recording is playing, these controls (with exception of the slider control) will fade away to show as much of the recording as possible. Moving the mouse pointer near the controls will display them again. The name, the start time and the end time of the recording are also displayed at the bottom of the display section, and fade away in the same way as the controls.

Because of these new controls, the *Manual* playback mode is now obsolete. You can now only select the *Keep repeating the recording* checkbox.

The following *SpectrumManagerHelper* methods have been implemented to support this:

- *SetSpectrumRecordingFrame (int frame)*: Sets the frame of the currently playing recording to the next available trace in the recording, starting from the given frame number.
- *SetSpectrumRecordingTime (TimeSpan time)*: Sets the currently playing recording to a specific point in time. The specified time span indicates the amount of time after the start of the recording where the playback should go.

#### Visual Overview: History mode for alarm states + culture option for datetime control \[ID_29822\]

When shapes in Visual Overview are linked to an element, parameter or service, it is now possible to show the alarm state for this linked object at a specific point in the past. To do so, you can use the new shape data *HistoryMode*, which can be added to a specific shape, or to the entire page.

The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

> [!NOTE]
> This feature is currently not yet supported for shapes linked to views.

An additional change introduced by this release note is that you can now define the culture that should be used for a shape that has been turned into a datetime control (using the *SetVarOptions* shape data set to *Control=DateTime*). To do so, add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

#### EPM: Topology diagram will now display the topology cell name instead of the table name \[ID_29842\]

An EPM topology diagram will now display the topology cell name instead of the table name.

Also, table names can now be overridden in the information template. If names of column parameters contain the table name, it is advised to also override these names in order to avoid confusion.

#### Generating a report based on a dashboard: New 'Include CSV' option \[ID_29933\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app. When you click the *Configure* button, you will now notice a new “Include CSV” option. If you select this option, the email will not only include the report but also a zip file containing a CSV file for every Pivot table, GQI table and Line & area chart component in the dashboard.

#### Visual Overview: History mode for spectrum thumbnails \[ID_30130\]

It is now possible to have a spectrum thumbnail in Visual Overview show the trace from a specific moment in the past, based on the recorded trending for a parameter in a spectrum monitor.

The trended trace record from right before the specified time will be displayed. For this purpose, the trended traces are queried with the following steps until a trace record is found or the maximum search extent has been reached: 1 hour – 3 hours – 12 hours – 24 hours – 48 hours (maximum).

To configure this:

1. Configure the shape in the same way as for a regular spectrum thumbnail, but as the parameter ID, specify the ID of the spectrum monitor trace parameter (which is always in the range 50000 - 59999). You can find this ID in the file *SpectrumMonitors.xml* in the folder *C:\\Skyline DataMiner*.

2. Add the *HistoryMode* shape data field to the shape, and configure its value as follows:

    ```txt
    State=[On/Off]|TimeStamp=[datetime value]
    ```

    Refer to the table below for the value syntax:

    | Value | Explanation |
    |-------|-------------|
    | State | Can be "On" or "Off". On means history mode is active, Off means the real-time spectrum trace should be shown instead. You can use a placeholder to change this value dynamically. |
    | TimeStamp | The date and time for which the spectrum trace should be displayed. You can use a placeholder to change this value dynamically. |

For example:

| Shape data field | Value                                                 |
|------------------|-------------------------------------------------------|
| Element          | 113/333                                               |
| Parameter        | 50016\|11\|trace_2mps\|5\|DisplayLabels;DisplayTime\| |
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\]                    |

#### Visual Overview: New Collapse shape data field \[ID_30149\]

In Visual Overview, you can now hide a shape in a different way than with the *Hide* shape data field, using the new *Collapse* shape data field. This field is configured in the same way, as detailed under [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions) in the DataMiner Help. While on the face of it, the result of the *Collapse* action will be the same as for a *Hide* action, the shape is hidden in a different way, i.e. its visibility is collapsed.

This makes it a convenient alternative to the *ChildrenFilter* shape data, as it will keep all shapes in memory instead of removing and recreating them. This will allow better performance, though it will lead to slightly increased memory usage.

Using the *Collapse* action can also be convenient in a grid layout, as a collapsed shape will not take up room in a grid, unlike a shape hidden using *Hide*.This can allow you to use the "Auto" width or height more effectively.

#### Visual Overview: New icons added to Icons stencils \[ID_30198\]

The following icons have been added to the Icons stencil:

- TV streaming
- Microservices

#### Visual Overview: History mode for parameter values of element shapes \[ID_30333\]

It is now possible to make an element shape in Visual Overview show the parameter values for a specific point in the past. This time and date can optionally be selected using another Visual Overview component.

To retrieve the value, DataMiner will use the trend record stored for the selected time. To know whether real-time or average trending should be retrieved, the latest trending configuration will be taken into consideration. If both types of trending are available, by default real-time trending will be used.

To configure this history mode, add the shape data *HistoryMode* to the element shape or to the entire page. The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

A number of options can also be added to the *HistoryMode* shape, again using a pipe character (“\|”) as separator:

| HistoryMode option | Description |
|--------------------|-------------|
| NoDataValue= | This option allows you to specify the text that should be displayed in case no trending is available. If this option is not specified, the default value “N/A” is displayed. For example: *State=On\|TimeStamp=\[var:myTime\]\|NoDataValue=\<No data available>* |
| TrendDataType | This option allows you to determine which kind of trend data should be used, if available: *Realtime* (default), *Average* or *RealtimeAndAverage*. |
| AverageTrendDataIndication | This option allows you to specify a prefix to the parameter value in case it represents an average value. By default, no prefix is shown. For example:  *State=On\|TimeStamp=\[var:myTime\]\|AverageTrendDataIndication=\[AVG\]* |

> [!NOTE]
>
> - You can override history mode on shape level. In case there are shapes within shapes, the lowest level will be checked first. However, the full shape data of this lowest level is used, so you must make sure that the shape data is fully configured even if you only want to change one option (e.g. NoDataValue).
> - At present, for history values no unit is displayed. In addition, only updating the element or parameter shape data will not update the history mode result.

If you are using a datetime control to set the date and time, use the *SetVarOptions* shape data and set the value to *Control= DateTime*. Optionally, you can also add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVar           | myTime                                    |
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

The following new placeholders are now also supported in an *Element* shape. These will only contain values in case history parameter values based on average trend data are displayed:

- \[average value\]
- \[minimum value\]
- \[maximum value\]

#### DataMiner Cube start window: Cleanup Cube Installation window \[ID_30351\]

When you click the cogwheel icon in the bottom-right corner of the DataMiner Cube start window, you can now select the *Cleanup* option to open the *Cleanup Cube Installation* window. That window will allow you to remove old and/or unused Cube versions as well as to clear the Visio cache and the protocol cache.

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

#### Aggregation rule conditions can now be specified in the form of a regular expression \[ID_30640\]

Aggregation rule conditions can now be specified in the form of a regular expression.

1. Set the condition type to “regular expression”.

2. Choose “by value” or “by reference”.

    - If you chose “by value” (i.e. the default setting), then enter a regular expression.
    - If you chose “by reference”, then select a single-value parameter of type “string” containing a regular expression.

#### Alarm templates: Conditions based on service impact \[ID_30691\]\[ID_30763\]

When editing an alarm template, it is now possible to configure alarm template conditions based on service impact.

#### Visual Overview: New ChildrenFilter 'ResourceMapping' \[ID_30751\]

When, within a service context, child shapes are automatically generated, it is now possible to use a ResourceMapping filter. This will allow you to only show shapes that have a certain role (mapped, unmapped, inheritance) within the booking.

In a child shape, add a data field of type *ChildrenFilter*, and set its value to “ResourceMapping=”, followed by one or more roles (separated by commas). If you specify multiple roles, all shapes of which the roles match one of the specified roles will be shown.

See the following example.

| Shape data field | Value                                       |
|------------------|---------------------------------------------|
| ChildrenFilter   | ResourceMapping=mapped,unmapped,inheritance |

> [!NOTE]
> Within a data field of type *ChildrenFilter*, you can specify multiple filters separated by pipe characters (“\|”). If you do so, only shapes matching all specified filters will be shown.

#### Visual Overview: Linking an element shape to a resource that is using that element \[ID_30752\]

It is now possible to link an element shape to a resource that is using that element.

To link an element shape to the last-known resource using the element in question, add a data field of type “Options” and set its value to “UseResource=True” (default value is false).

| Shape data field | Value            |
|------------------|------------------|
| Options          | UseResource=True |

> [!NOTE]
>
> - Within a service instance connectivity chain, the elements will automatically be linked to the resource.
> - Children of an element shape in which the “UseResource” option is specified will automatically inherit this setting unless overridden.

##### Placeholders that can retrieve resource-related data

When a resource is linked to an element shape, you can use the following placeholders to retrieve data from that resource.

| Placeholder | Data |
|--|--|
| \[Element Name\] | The name of the resource’s function element, if such an element could be found. If none could be found, this placeholder will contain the name of the element linked to the element shape. |
| \[Function Name\] | The name of the resource function. |
| \[Name\] | The name of the element linked to the element shape. |
| \[Resource ID\] | The ID of the resource (GUID). |
| \[Resource Name\] | The name of the resource. |

#### Visual Overview: New \[ServiceDefinition:\] placeholder & new \[Reservation:\] placeholder property 'ServiceDefinitionID' \[ID_30757\]

##### New \[ServiceDefinition:\] placeholder

The new \[ServiceDefinition:\] placeholder allows you to retrieve one of the following properties of a service definition:

| Property                 | Description                                                                                                                                                                                                  |
|--------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Name                     | The name of the service definition.                                                                                                                                                                          |
| Actions                  | The name of the scripts that are defined on the service definition. Names of multiple actions will be separated by colons (“:”). This will allows them to be inserted directly into e.g. a setvar shape. |
| Property=\<propertyName> | The value of any of the custom properties of the service definition.                                                                                                                                         |

Full syntax: \[ServiceDefinition:\<ServiceDefinitionID>,\<Property>\]

##### New \[Reservation:\] placeholder property 'ServiceDefinitionID'

The \[Reservation:\] placeholder now allows you to retrieve the service definition ID of a specific booking.

Full syntax: \[Reservation:\<Service ID or Booking ID>,ServiceDefinitionID\]

#### Logging now contains more information regarding system performance \[ID_30769\]

The Cube log files will now contain more information regarding system performance.

> [!NOTE]
> A new checkbox at the top of System Center’s Logging page will allow you to show or hide these System Performance Indicator (SPI) log entries.

#### Logging: New log file 'Sharing Manager' \[ID_30826\]

The Logging module now also allows you to access the Sharing Manager log file.

#### DataMiner Cube - Router Control: 'Direct take' mode \[ID_30865\]

When configuring a matrix in the Router Control module, you can now set it to either “preset mode” (i.e. the default mode) or “direct take mode”.

- In preset mode, you need to click the *Connect* button to create or delete a crosspoint between an input and an output.
- In direct take mode, you don’t need to click the *Connect* button to create or delete a crosspoint between an input and an output. When you select an input and an output, they will automatically be connected or disconnected.

> [!NOTE]
> When you use direct take mode in combination with the “Use output-first workflow” option
>
> - selecting an output will not cause crosspoints to be created or deleted, and
> - input selections will only be cleared when you select another output.

#### Sidebar: 'Advanced search' improvements \[ID_30885\]

Up to now, the advanced search pane was only added to the sidebar after you entered a search string in the search box in the middle of the Cube header bar and then clicked the “Advanced search for” option at the bottom of the suggestions list. From now on, you can directly open the advanced search pane by clicking the ellipsis button (“...”) in the sidebar and selecting the *Search* button.

In addition, there is now a search box at the top of the advanced search pane, so you can search from directly in the pane.

#### DataMiner Agent will no longer be selected by default when creating a new element on an DataMiner System with multiple agents \[ID_30889\]

When you created an element on a DataMiner System with multiple agents, up to now, the DMA to which you were connected would by default be selected in the DMA selection box. To prevent users from all creating new elements on the same agent, from now on, whenever there are multiple agents in the DataMiner System, no agent will be selected by default.

> [!NOTE]
> When you duplicate an element, the DMA selection box will by default be set to the same DMA as the original element.

#### Visual Overview: Edge/WebView2 browser engine \[ID_30940\]

In DataMiner Cube, up to now, embedded webpages could be displayed using either Chromium or Microsoft Internet Explorer. From now on, it is also possible to use Microsoft Edge (WebView2).

Using this new Edge browser engine offers a number of advantages:

- The web content is rendered directly to the graphics card.
- The browser engine automatically receives updates via Windows Update, independent of DataMiner or Cube version.
- Proprietary codecs such as H.264 and AAC are supported.

To set this browser engine as the system default for all users, go to *System Center \> System Settings \> Plugins*, and set the *Web browser Engine* option to “Edge”.

If you want a shape to display a webpage using the Edge web browser regardless of Cube’s default browser engine setting, add a shape data field of type *Options* to the shape containing the web browser control, and set its value to “UseEdge”.

> [!NOTE]
>
> - Currently, the Edge web browser engine cannot be used in DataMiner web apps like Ticketing, Dashboards, etc.
> - The WebView2 Runtime will automatically be installed when using Office 365 Apps. It will also come pre-installed with Windows 11. It will not be included in DataMiner upgrade packages.

#### Sidebar: Pinning and unpinning sidebar items \[ID_30963\] \[ID_31207\]

It is now possible to pin and unpin items in the sidebar.

- To pin an item, click the Add button (“+.”), and then click the item you want to pin to the sidebar.
- To unpin an item, right-click the item in the sidebar, and click *Unpin*.

> [!NOTE]
> One of the items you can pin after clicking the Add button (“+”) is the “Overview” button. Clicking this button after it has been pinned will open a card showing the root view (Below this view \> All).

#### Visual Overview: Setting the background color of a static shape using a shape data field of type 'BackgroundColor' \[ID_30964\]

Using a shape data field of type *BackgroundColor* it is now possible to set the background color of a static shape, i.e. a shape that is not linked to an element, a service or a view.

| Shape data field | Value    |
|------------------|----------|
| BackgroundColor  | \<color> |

The \<color> value in the example above can be specified as follows:

- An HTML color code (e.g. #FF102030)
- An RGB color code (e.g. 40,50,60)
- A standard color name (e.g. magenta)
- A color placeholder referring to one of the configured DataMiner alarm colors (e.g. \[color:severity=minor\])
- A placeholder referring to a variable containing a color value (e.g. \[PageVar:MyColorSessionVar\])

> [!NOTE]
>
> - If you specified a valid color or if the placeholder resolves correctly, the color you specified will overrule the shape’s default background color. Note that if blinking was enabled, it will be disabled.
> - If you specify a custom BackgroundColor, shape transparency will work as before.

#### System Center - Analytics config: New setting 'Maximum group size' \[ID_30993\] \[ID_31093\]

In the *System settings \> Analytics config* section of *System Center*, a new setting has been added for automatic incident tracking. The *Maximum group size* setting will now allow you to limit the size of the alarm groups.

When an alarm group reaches the maximum size specified in this setting, a new group will be created with all remaining alarms that belong to the same incident.

Default value: 1000

> [!NOTE]
> In the *System settings \> Analytics config* section of *System Center*, the setting names have been adjusted to improve consistency. “Minimal” has been replaced with “Minimum” and “Maximal” has been replaced with “Maximum”.

#### Visual Overview: New \[Element:\] placeholder \[ID_31158\]

In Visual Overview, you can now use the new “\[Element:\<input>,\<output>\]” placeholder to convert an element name to an element ID and vice versa.

\<input> can be set to

- an element name, or
- an element ID (dmaID/elementID).

\<output> can be set to

- “Name”, or
- “ID”.

Examples:

- \[Element:MyElement,ID\] will be resolved to the ID of the element with the name “MyElement”.
- \[Element:2/125,Name\] will be resolved to the name of the element with ID 2/125.

#### DataMiner Cube - Visual Overview: Service connectivity chains now support 'lite contributing' resources \[ID_31196\]

In Visual Overview, it is possible to have the connectivity chain of a service instance (from the Service & Resource Management module) drawn automatically in Visual Overview. Now, this feature supports so-called “lite” contributing resources, i.e. resources for which no enhanced elements have to be created.

#### Automatic Incident Tracking: New setting 'Maximum group events rate' \[ID_31203\]

In *System Center*, a new setting has been added to the *Analytics config* section: “Maximum group events rate”. With this setting, you can limit the maximal number of alarm group events that will be generated and thus avoid any possible performance issues during alarm floods.

When more events are generated per second than the value specified in this setting, the generation of events will be slowed down, and as soon as the number of generated events drops below the threshold again, the generation of events will again proceed at the fastest speed possible.

Each time alarm grouping enters flood mode, a notice alarm will be generated to notify users that they may experience a delay when checking the alarm group information shown by Cube. If this notice alarm is not cleared manually, it will be cleared automatically when the alarm flood has passed.

Default value of the “Maximum group events rate” setting: 100

#### Visual Overview: New icons added to Icons stencils \[ID_31271\]

The following icons have been added to the Icons stencil:

- Action
- Cloudy
- Cloud Formation
- Response
- Request
- Media Connect
- Groups
- Media Live
- Media Package
- Mist
- Moon
- Pairs
- Parameter
- Rain And Snow
- Qactions
- Rain
- Rain Percentage
- Snow
- Semi Cloudy
- Storm
- Snowflake
- Sunset
- Sun
- Umbrella
- Thunder
- Wind Direction
- Weather Forecast
- Wind

#### Services app: Enhanced service definition security \[ID_31306\] \[ID_31428\]

In the Services app, a number of security enhancements have been made with regard to service definitions.

- In the *Users/Groups* section of System Center, the *Add*, *Edit* and *Delete* permissions under *Modules \> Services \> Definitions* have now been replaced by one single *Edit actions* permission. If a user had at least one of those previous *Add*, *Edit* or *Delete* permissions, they will now automatically be granted the new permission.

- In some cases, the *Diagram* and *Properties* permission under *Modules \> Services \> Definitions* would be applied incorrectly.

- Users who do not have read permission on functions will now be able to correctly save function nodes when configuring service definitions.

#### Legacy Reports, Dashboards and Annotations modules will by default be hidden in new installations \[ID_31329\]

In new installations, from now on, the legacy Reports, Dashboards and Annotations modules will be hidden by default.

If you do not want these modules to be hidden, you can set the LegacyReportsAndDashboards and/or LegacyAnnotations soft-launch options to true.

#### Alarm Console - Context menu: Links to elements, services and views in 'Open' submenu now have an element, service or view icon in front of them \[ID_31499\]

When you right-click an alarm in the Alarm Console, the *Open* submenu contains a link to the alarm card as well as links to all elements, services and views affected by the alarm. From now on, the links to the elements, services and views will each have an element, service or view icon in front of them.

#### Filter will now be taken into account when exporting a table \[ID_31586\]

Up to now, when you filtered a table and then exported it, the filter would not be taken into account and the entire table would be exported. From now on, the filtered table will be exported instead.

#### DataMiner Cube - Views: 'Below this view' list has a new column 'Communication protocols' \[ID_31590\]

A “Communication protocols” column has been added to the list on the *Below this view* page of a view card. This column will show the communication protocols used by an element.

#### System Center - Users/Groups: New user permission 'Monitoring web app' \[ID_31706\] \[ID_31961\]

In the *General* section of the user permissions list, a new “Monitoring web app” permission has now been added next to the existing “DataMiner web apps” permission. This permission can be used to control access to the Monitoring web app.

This user permission is enabled by default.

#### DataMiner Cube desktop app: Support for system-wide installation via a shared MSI installer \[ID_31874\] \[ID_32154\]

The DataMiner Cube desktop app, which allows side-by-side installation of different Cube versions, now supports system-wide installation via a shared MSI installer.

> [!NOTE]
> When you install the DataMiner Cube desktop app by means of a shared MSI installer, all automatic updates will now be blocked. To update the DataMiner Cube desktop app, the administrator will need to install a new MSI file.
>
> Also, Cube will no longer attempt to download and install the CefSharp package automatically. This will now have to be installed manually using the separate CefSharp MSI installation package.

#### System Center - Users/Groups: Renamed user permissions \[ID_32141\]

For reasons of consistency, the following user permissions have been renamed:

| Old name                                     | New name                                |
|----------------------------------------------|-----------------------------------------|
| Best practices analyzer \> Read              | Best practices analyzer \> UI available |
| Alarm templates \> Add alarm templates       | Alarm templates \> Add                  |
| Alarm templates \> Edit alarm templates      | Alarm templates \> Edit                 |
| Alarm templates \> Delete alarm templates    | Alarm templates \> Delete               |
| Trend templates \> Configure trend templates | Trend templates \> Configure            |

#### Visual Overview: \[ServiceDefinition:...\] placeholder now allows you to look up a node ID by passing a node label \[ID_32222\]

Inside a \[ServiceDefinition:...\] placeholder, it is now possible to look up a node ID by passing a node label. See the following example.

```txt
[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]
```

This will, for instance, allow you to find a resource by passing a label of a service definition node. See the following example.

```txt
[Reservation:[this service],ResourceID|NodeID=[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]]
```

#### Visual Overview: URI scheme of the DataMiner Agent in question will now automatically be used when resolving the \<DMAIP> placeholder \[ID_32249\] \[ID_32349\]

The \<DMAIP> placeholder can only be used inside another placeholder, or in a URL for a shape data field of type Link. It is replaced with the first configured value from the following list that can be found for the DMA you are connecting to: the certificate address, the hostname or the primary IP address.

When the \<DMAIP> placeholder is resolved, from now on, the URI scheme of the DataMiner Agent in question (i.e. HTTP or HTTPS) will automatically be applied.

> [!NOTE]
> When a \<DMAIP> placeholder does not represent the URI host (e.g. when it is used as a query argument), the URI scheme of the DataMiner Agent (i.e. HTTP or HTTPS) will not automatically be applied.
