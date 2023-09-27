---
uid: General_Feature_Release_10.0.3
---

# General Feature Release 10.0.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### New SLNet setting 'ClusterTransitionStateTimeout' in MaintenanceSettings.xml \[ID_22136\]

In the *MaintenanceSettings.xml* file, you can now specify a cluster transition state timeout (in seconds).

If you do so, DataMiner Agents leaving the DataMiner System (i.e. cluster) will leave the transition state after the above-mentioned timeout delay, starting from the last received notification from any of the DataMiner processes. This will prevent DataMiner Agents from getting stuck in the transition state.

```xml
<SLNet>
  <ClusterTransitionStateTimeout>5</ClusterTransitionStateTimeout>
</SLNet>
```

#### Dynamic table filters: New component type 'recursivefullfilter' \[ID_24672\]\[ID_24676\]

When configuring a dynamic table filter, you can now add a filter component of type “recursivefullfilter”.

This type of component will allow you to filter keys when using the recursive option. It follows the same syntax as the “fullfilter” component, and is applied to all keys found through recursive links when requesting a table with the recursive option.

Example:

```txt
recursivefullfilter=(1002 > 0)
```

> [!NOTE]
> This new filter component can also be used in table filters specified in a DataMiner Maps configuration file.

### DMS Protocols

#### Serial clients can now parse data past the trailer of a response of which the length is defined in a parameter of type 'next param' \[ID_24442\]

From now on, when serial clients receive a response with a variable length (specified in a parameter of type “next param”), they will be able to parse it correctly when the trailer is not at the very end, but only if the following conditions apply:

- The response has to contain a trailer that is set before the data parameter. It does not have to contain a header.
- A length parameter should be located before the data parameter. It should be of length type “next param” and raw type “numeric text”.
- The length parameter has to be located either between two fixed parameters (e.g. “header before” and “trailer after”) or at the beginning of the response.

Up to now, when a response like the one in the example below was received, the data at the end would only be read after the command had timed out.

```txt
[header][length parameter (next param)][fixed-length parameter][another parameter of any type][trailer][data with length defined in length parameter]
```

#### NT_DELETE_FOLDER (182): Option added to bypass DataMiner recycle bin \[ID_24639\]

The NotifyDataMiner function “NT_DELETE_FOLDER” is now able to bypass the DataMiner recycle bin.

- If the function is called with its second argument set to true, the item specified in the first argument will be moved to the DataMiner recycle bin (default behavior if no second argument is passed).
- If the function is called with its second argument set to false, the item specified in the first argument will not be moved to the DataMiner recycle bin. Instead, it will physically be deleted.

Example:

```csharp
string folderName = "Configurations";
bool bRecycle = true;
protocol.NotifyDataMiner(182 /*NT_DELETE_FOLDER*/, folderName, bRecycle);
```

> [!NOTE]
> If a relative path is passed to the NT_DELETE_FOLDER function, it will assume it to be relative to the *C:\\Skyline DataMiner\\Documents\\* folder. So, in the example above, the function will try to delete the *C:\\Skyline DataMiner\\Documents\\Configurations* folder. If you want it to delete the *C:\\Skyline DataMiner\\Configurations* folder, then you have to specify the full path.

### DMS Cube

#### Visual Overview: Adding a search box to a SetVar selection box control \[ID_24448\]

Using a *SetVar* data field, you can turn a shape or a page into a selection box control that allows users to update a session variable. From now on, it is possible to add a search box to such a selection box.

To do so, specify “Control=FilterComboBox” in a *SetVarOptions* data field. See the following example:

| Shape data field | Value                                             |
|------------------|---------------------------------------------------|
| SetVar           | \[Sep::;\]MySessionVariable;\[Param:25/1245,568\] |
| SetVarOptions    | Control=FilterComboBox                            |

> [!NOTE]
> HTML5 mobile apps do not support selection boxes with a search box. Selection boxes that have a search box configured will be displayed as regular selection boxes without search box.

#### Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption \[ID_23462\]

Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption.

If you want such an element to use SSL/TLS encryption, then do the following:

1. Right-click the element, and select *Edit*.
1. In the *Edit* tab, go to the *Serial connection* section containing the settings of the port in question, and select the *SSL/TLS* checkbox.

> [!NOTE]
> DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1).
>
> Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.

#### Visual Overview: New option to disable path highlighting when clicking a connection line \[ID_24544\]

Up to now, when you clicked a connection line between shapes, the path connected to that line was highlighted by default.

This default behavior can now be changed by adding a *SelectionHighlighting* option to the shape that represents the connection and setting it to “False”. See the following example.

| Shape data field | Value                       |
|------------------|-----------------------------|
| Connection       | Connectivity                |
| Options          | SelectionHighlighting=False |

#### DBMaintenance.xml/DBMaintenanceDMS.xml: New TTL type 'cjobsection' \[ID_24549\]\[ID_24575\]

In the *DBMaintenance.xml* and *DBMaintenanceDMS.xml* files, you can configure the “time to live” (TTL) settings of different types of database records. From now on, you can also specify TTL settings for job objects stored in an Elastic database.

See the following example:

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

#### Visual Overview: New FilterContext option for shape linked to alarm filter \[ID_24577\]

When a shape is linked to an alarm filter, you can now add an additional element, service or view filter to the *AlarmSummary* shape data, using a pipe symbol ("\|") as separator. The syntax of this filter is "*FilterContext=*" followed by the name or ID of the element, service or view.

If you have configured the shape to open an alarm tab in the Alarm Console when it is clicked, this filter will also be taken into account for the alarm tab. For example:

| Shape data field | Value                                                       |
|------------------|-------------------------------------------------------------|
| AlarmSummary     | active\|MyFilterName\|false\|Alarm\|FilterContext=MyService |
| AlarmTab         | Name=MyFilteredTab                                          |

#### Visual Overview: New Set option 'SetTrigger=Event' & additional IOClicked event arguments \[ID_24582\]

##### New Set option 'SetTrigger=Event'

Up to now, in a page-level shape data field of type *Execute*, you could specify the “SetTrigger=ValueChanged” option in a *Set* command to have parameters or session variables updated on an open Visual Overview page when a specific value changes.

From now on, it is also possible to have a *Set* command update parameters or session variables on an open Visual Overview page when an event occurs on that page. To do so, you have to specify the “SetTrigger=Event” option.

In the following example, every time the event is triggered from the router control, the set command will be executed with the label of the clicked matrix. Clicking the same input or output multiple times will each time cause the set command to be executed. Note that, if you would specify “SetTrigger=ValueChanged” instead of “SetTrigger=Event”, clicking the same input or output multiple times would cause the set command to be executed only once.

| Shape data field | Value                                                      |
|------------------|------------------------------------------------------------|
| Execute          | Set\|1/1\|350\|\[Event:IOClicked,Label\]\|SetTrigger=Event |

> [!NOTE]
> All *Set* commands with a “SetTrigger=Event” option will be triggered when an event occurs, even those that do not contain an \[Event:\] placeholder.

##### Additional IOClicked event arguments

The following additional arguments can now be specified when configuring the router control event “IOClicked” in an \[Event:\] placeholder:

| Argument | Description                                                       |
|----------|-------------------------------------------------------------------|
| Type     | “input” or “output”, depending on the type of the interface.      |
| Matrix   | The name of the matrix that contains the clicked input or output. |

#### Visual Overview: New MinChartHeight parameter option for trend component \[ID_24706\]

It is now possible to configure the minimum height of the chart area of a trend component. Previously, this was always set to 200 pixels. To make sure this height is reached, the legend of the trend component will become smaller when necessary, or it may even be hidden.

To configure the minimum height of a trend component, add the option *MinChartHeight* to the *ParametersOptions* shape data.

For example, with the configuration below, the minimum height of the chart area will be 400 pixels.

| Shape data field  | Value                               |
|-------------------|-------------------------------------|
| Component         | Trending                            |
| ParametersOptions | ShowLegend:true\|MinChartHeight=400 |
| Parameters        | 1/20:500:\*                         |

### DMS Reports & Dashboards

#### Dashboards app: Parameter feed now has a 'Selected only' toggle button \[ID_24446\]

The parameter feed allows you to select multiple parameters from a predefined list. At the top of the list, a box allows you to select or deselect all items in the list at once and, from now on, a “Selected only” toggle button will also allow you to show or hide items that are not selected.

#### Dashboards app: New Auto-expand parameters setting for parameter feed \[ID_24682\]

A new setting, *Auto-expand parameters*, is now available for the parameter feed component. If this setting is selected, all tables and groups in the component will by default be expanded.

#### Dashboards app: New Bookings data set & Node edge graph component improvements \[ID_24480\]

A new *Bookings* data set is now available in the Dashboards app, which can be filtered on a specific time range. This can be used to add booking data to a *Drop-down*, *List* or *Tree* feed component. If the entire booking data set is added, a time range feed should also be added as a filter. Booking data can also be added as a filter to a *Node edge graph* component. To specify a booking data feed in a URL, specify *bookings=bookingsID*.

Because it is now possible to use a booking data filter, the *Reservation instance ID* setting is no longer available for the *Node edge graph* component. If a service filter is used for this component, it must be linked with a time range feed. Finally, the *Service definition* setting for the *Node edge graph* component has been changed from a text box to a drop-down list.

### DMS CPE Management

#### CPECollector API: New methods \[ID_21755\]

The following methods have been added to the CPECollector API:

`GetMaskedDMAObjectRefTrees(FilterElement<IDMAObjectRef>)`

This method returns all masked object trees that match the specified filter. If no filter is passed, then all masked object trees are returned.

In the following example, a filter is passed to check whether the view with ID 2 is masked.

```csharp
var managedFilter = new ManagedFilter<DMAObjectRefTree,IDMAObjectRef> (DMAObjectRefTreeExposers.Data,Comparer.Equals, new ViewID(2),null);
```

**GetMaskedDMAObjectRefTrees(managedFilter);**

This method returns mask operations stored in the transaction store (i.e. masking of topology data or views).

#### DataMiner Cube: Masking of CPE objects and views related to CPE objects \[ID_22185\]

In DataMiner Cube, it is now possible to mask views related to CPE objects. You can mask views in the Surveyor tab, in the Recent Items tab, in topology diagrams and in the table on the *BELOW THIS VIEW* page of a view card.

Also, CPE objects can be masked and/or unmasked via alarms. If you right-click an alarm of which the properties ‘System Name’ and ‘System Type’ refer to a CPE object, a dialog box will appear, allowing you to either mask only the alarm or mask the CPE object and all active alarms linked to that CPE object.

#### DataMiner Cube: Term 'CPE' replaced by 'EPM' \[ID_24568\]

In DataMiner Cube, the term “CPE” (Customer Premises Equipment) has been replaced by “EPM” (Experience and Performance Management).

### DMS Mobile apps

#### Monitoring app: Histogram page added to view card \[ID_24517\]

In the Monitoring app, view cards now have a histogram page.

On that page, you can select a parameter of any protocol associated with an element in the view, and then click *Show histogram*.

The following options can be configured:

| Option | Description |
|--|--|
| Include subviews | Select this option if you want to be able to also select parameters belonging to protocols associated with elements only found in subviews. Default: Selected. |
| Use relative frequency | Select this option if you want the Y-axis frequencies to be shown as percentages. Default: Not selected. |
| Use custom intervals | Select this option if you want to be able to specify the amount of intervals and the interval range (minimum and maximum value). Default: Not selected. |

> [!NOTE]
> The selected parameter and the histogram options are also added to the URL. That way, you can easily save or share a link to a specific histogram view.

#### Monitoring app: View card and service card now have Alarms, Notes and Reports pages \[ID_24723\]

The following pages have now been added to both the view card and the service card:

| Page | Description |
|--|--|
| Alarms | Page that lists the active alarms of the view or service in question. Hidden when the user does not have access to alarms. |
| Notes | Page where users can add, edit or delete notes regarding the view or service in question. |
| Reports | Page that shows a basic report for the view or service in question (from the legacy Reporter module). Hidden when the user does not have access to the legacy Reporter module. |

> [!NOTE]
> The above-mentioned pages can all be accessed directly via a URL.

#### Monitoring app: Loading indicator when opening cards \[ID_24734\]

When, in the Monitoring app, you are opening a card, a loading indicator will now be displayed at the top of the card until it is fully loaded.

## Changes in DataMiner 10.0.3

### Enhancements

#### Enhanced masking of DataMiner objects \[ID_20033\]\[ID_21654\]

A number of enhancements have been made with regarding to the masking of DataMiner objects (elements, alarms, redundancy group, DVE elements) via user interfaces or Automation.

> [!NOTE]
> All masking information of alarms and elements will now be stored in the *maskstate* table.

#### Run-time errors will now be generated when SLDataMiner halts while executing start, stop or restart actions for elements \[ID_24228\]

When, for whatever reason, SLDataMiner should halt while executing start, stop or restart actions for a particular element, from now on, a run-time error will be generated.

#### DataMiner Cube: Enhanced user picture icons in search results \[ID_24364\]\[ID_24573\]

A number of enhancements have been made to the user picture icons that appear in search results. Those icons will now also indicate whether a user is online, and when no user picture could be found, a default user icon will now be displayed instead.

Also, a user picture icon will now be displayed in the top-left corner of a user card.

#### Service & Resource Management: State icons in Services list now centered \[ID_24396\]

In the Services list of the Services app or a service list Visio component, the state icons will now be centered in their column.

#### DataMiner Cube - Alarm Console: Enhanced visibility of focus icons in Skyline Black theme \[ID_24476\]

In the *Active alarms* tab page, for each alarm that can be considered “unexpected”, an icon is displayed in the *Focus* column. Those focus icons now have an enhanced visibility, especially in the Skyline Black theme.

#### No more synchronization error notices after deleting services \[ID_24479\]

Up to now, in case a service had been deleted in a DMS, it could occur that unnecessary notices were generated that there was an error in synchronization. From now on, such notices will no longer be generated.

#### Dashboards app: Button and button panel visualizations are no longer available \[ID_24514\]

The button visualization and button panel visualization are no longer available in the Dashboards app.

#### DataMiner Cube - Trending: Intermediary points added when exporting a trend graph as line graph \[ID_24580\]

If, when exporting trend data to CSV, you select the *Line graph instead of block graph* option, from now on, intermediary points will be added if no data is available at certain timestamps (which can happen when a value remained constant).

Depending on the step size of the data points, a point will be added at fixed intervals. Previously, points would only be added when a value changed.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents will no longer be cached by SLNet \[ID_24581\]

From now on, AlarmFocusEvents generated by SLAnalytics will no longer be cached by SLNet.

#### DataMiner Cube - Data Display: Matrices with more than 1000 inputs and outputs will no longer have an 'Expand pages' button \[ID_24589\]

From now on, in order to prevent users from expanding large matrices, matrices with more than 1000 inputs and outputs will no longer have an “Expand pages” button.

#### DataMiner Cube: Activity panel layout enhancements \[ID_24592\]

In the Activity panel, a number of small layout enhancements have been made, especially with regard to spacing between icons and text.

#### DataMiner Cube - Service & Resource Management: Possibility to instantiate functions without entry point table \[ID_24594\]

In the Resource Manager app, it is now possible to instantiate functions without an entry point table.

- The function DVE needs to be activated manually in the *Generic DVE table* section of the main element’s *General parameters* page.

- The names of the resource and the function DVE will need to be changed in the *Edit resource* window.

  - Default resource name: The name of the function.
  - Default function DVE name: The name of the function with an automatically incremented suffix.

#### DataMiner Cube - Visual Overview: Signal path update enhancements \[ID_24599\]

Due to a number of enhancements, overall performance has increased when updating signal paths.

#### Rollback packages will no longer be created during a DataMiner upgrade \[ID_24614\]

During a DataMiner upgrade, a rollback package will no longer be created.

To downgrade to a specific DataMiner version, from now on, it will suffice to install the full installation package of that earlier DataMiner version.

> [!NOTE]
> In the DataMiner Taskbar Utility, the *Rollback* option has also been removed from the *Maintenance* menu.

#### DataMiner installer - MySQL: 'sql_mode' setting no longer set to STRICT_TRANS_TABLES by default \[ID_24653\]

When you install a DataMiner Agent with a MySQL database, the DataMiner installer will now set the sql_mode setting to “” in the my.ini file.

#### Changing parameter names for a DVE child element is no longer possible \[ID_24669\]

It is no longer possible to change parameter names for a DVE child element. The *Parameter names* command will therefore no longer be available in the card header menu after opening a DVE child element.

#### DataMiner Cube: Enhanced 'Back' buttons in card headers and browser controls \[ID_24693\]

In card headers and browser controls, the *Back* button will now always be visible, either enabled or disabled.

Also, the layout of WFM card headers has been optimized.

#### Dashboards app: Changes to behavior table parameter subscriptions \[ID_24702\]

The following changes have been implemented to the behavior of table parameter subscriptions in the Dashboards app:

- When a column filter is specified, the client will only receive updates if the updated cell is part of a filtered column. This change also applies to the web API in general.

- In the drop-down, list and tree feeds, the indices will now be updated in real time if WebSockets are enabled. If WebSockets are not enabled, the indices will be fetched initially and then a message will be displayed to notify the user that WebSockets must be enabled in order to retrieve updates.

#### DataMiner Cube: Enhanced app icons \[ID_24718\]

In DataMiner Cube, the layout of all app icons has now been enhanced.

#### Dashboards app: Grouping enhancements \[ID_24719\]

A number of enhancements have been made with regard to grouping, especially when grouping by index.

#### Dashboards app: Enhanced 'No data' error message in Line chart component \[ID_24737\]

Up to now, when no data could be displayed in a Line chart component, a general “No data” error message would be displayed. This general message has now been replaced by a more specific error message: “No data within the specified time range”.

#### DataMiner backup: Full backup now includes booking data stored in Indexing Engine \[ID_24766\]

When you take a full backup of your DataMiner System, from now on, the booking data stored in Indexing Engine will also be included.

#### Outdated version number removed from DataMinerCubeStandAlone web page \[ID_24871\]

Up to now, the following HTML file contained an outdated DataMiner Cube version number. That number has now been removed.

- C:\\Skyline DataMiner\\Webpages\\DataMinerCubeStandalone\\publish.htm

#### DataMiner Cube - Side bar: Enhanced loading of app icons in App list \[ID_24891\]

Due to a number of enhancements, overall performance has increased when loading the app icons in the Apps list.

#### Maximum upload size for upgrade packages increased from 500 MB to 4,000 MB \[ID_24922\]

The maximum upload size for upgrade packages has increased from 500 MB to 4,000 MB.

### Fixes

#### Problem in SLDataMiner after handling large number of notifications \[ID_24091\]

A problem could occur in the SLDataMiner process after it handled a large number of notifications.

#### Elements missing from SLElementInProtocol.txt log file \[ID_24115\]

In some cases, elements would be missing from the SLElementInProtocol.txt log file.

#### Service & Resource Management: ReservationInstances after midnight would be generated incorrectly when a DailyRecurrence was defined \[ID_24166\]

When a DailyRecurrence was defined in a ReservationDefinition, in some cases, the ReservationInstances after midnight would be generated incorrectly depending on the time zone.

#### DataMiner Cube - Visual Overview: Updates of child states or properties of a deleted element, service or view would incorrectly trigger shape updates \[ID_24337\]

When an element, service or view was deleted, in some cases, updating child states or properties of that deleted items could incorrectly trigger shape updates in Visio.

From now on, when an element, service or view is deleted, Visual Overview will disregard any updates made to child states or properties of that deleted item.

#### Web Services API v1: Incorrect view alarm severity \[ID_24347\]

The view state returned by the following methods would incorrectly not take into account the user security.

- GetAlarmStateForView
- GetView
- GetViewsForParent

> [!NOTE]
> The above-mentioned methods are also used by the DataMiner web applications (e.g. Monitoring & Control, Dashboards, Ticketing, etc.), and the view states are also used in DataMiner Maps.

#### DataMiner Cube - Automation/Scheduler: Problem when adding multiple recipients with an identical 'full name' in the To field of an Email action \[ID_24373\]

In some cases, an error could occur when you added multiple recipients with an identical “full name” in the *To* field of an *Email* action.

#### DataMiner Cube - Protocols & Templates: Problem when opening an alarm template \[ID_24453\]

In some cases, an exception could be thrown when, in a DataMiner Cube running on a Windows 7 computer with Microsoft .NET Framework 4.0, you opened an alarm template of a protocol that had a page button visualized on multiple DATA pages.

> [!NOTE]
> We recommend to always upgrade to the latest .NET Framework version.

#### DataMiner Cube - Alarm Console: Masked alarms tab page incorrectly had a Focus column \[ID_24455\]

Since DataMiner version 10.0.1, the *Active alarms* tab page has a *Focus* column, in which an icon is displayed for each alarm that can be considered “unexpected”.

Up to now, this *Focus* column would also incorrectly be present on the *Masked alarms* tab page.

#### Service & Resource Management - Bookings app: Amount of bookings displayed on the bookings timeline did not match the amount of bookings listed in the bookings list \[ID_24460\]

In the Bookings app, in some cases, the amount of bookings displayed on the bookings timeline would not match the amount of bookings listed in the bookings list.

#### Problem with SLDataGateway when retrieving recursive tree items \[ID_24461\]

In some cases, an error could occur in SLDataGateway when retrieving recursive tree items.

#### SNMP managers would not start sending traps after a DataMiner Agent had started up \[ID_24478\]

When a DataMiner Agent had started up, in some cases, the SNMP managers configured to resend SNMP notifications for active alarms at regular intervals would not start sending traps.

Also, when an SNMP manager was updated while it was sending a trap, in some cases, an error could occur.

#### Problem when SLProtocol retrieved data from a logger table \[ID_24483\]

In some cases, a problem could occur when SLProtocol retrieved data from a logger table using an integer value as primary key.

#### DataMiner Cube - Automation: IF action's 'Wait for positive result for at most' values not readable in entry box \[ID_24497\]

When configuring an IF action in an Automation script, it is possible to select the *Wait for positive result for at most* option and enter a time span, in order to make the script wait during the specified period before evaluating the If condition. Due to a font color issue, the values in that entry box would not be readable.

#### Memory leak in SLXML due to a parsing issue in SLDataMiner \[ID_24503\]

In some cases, SLXML could leak memory due to an XML parsing issue in SLDataMiner.

#### DataMiner Cube: Backup could incorrectly be started while the backup settings of the Indexing engine were being configured \[ID_24510\]

Up to now, users would incorrectly be able to start a backup operation while the Indexing nodes were restarting after, for example, changing the Indexing engine’s backup path.

From now on, it will no longer be possible to start a backup operation while the backup settings of the Indexing engine are being configured.

#### Problem with SLDataMiner \[ID_24511\]

In some rare cases, an error in SLDataMiner would cause other problems to occur (e.g. element timeouts).

#### Service & Resource Management: Editing a service in the services list would incorrectly clear the IDOfSelection session variable \[ID_24519\]

When you select a service in the services list, the ID of that service is stored in the *IDOfSelection* session variable. In some cases, that session variable would incorrectly be cleared when you edited the selected service.

#### DataMiner Cube: Weather service applet would incorrectly appear on the home page \[ID_24542\]

Prior to DataMiner version 9.6.5, the DataMiner Cube home page would show a weather service applet. In some cases, that applet would incorrectly appear again when switching between older and newer Cube versions.

#### DataMiner Cube - Visual Overview: Problem when sorting generated shapes that represent alarms \[ID_24550\]

When you used a group-level shape data field of type *ChildrenSort* to sort automatically generated shapes representing alarms, in some cases, those shapes would not be sorted correctly when sorted by an alarm property.

#### Virtual function impact change would incorrectly not trigger an update of the virtual function’s element state \[ID_24559\]

In some cases, a virtual function impact change would incorrectly not trigger an update of the virtual function’s element state.

#### DataMiner Cube: Clicking 'Open Cube Mobile' would not always direct you to the landing page \[ID_24560\]

When, in DataMiner Cube, you clicked *Open Cube Mobile*, in some cases, you were incorrectly directed to the Monitoring & Control app. From now on, clicking *Open Cube Mobile* will always direct you to the landing page.

#### All data retrieved from an SNMP table would incorrectly be dropped when some OIDs could not be found \[ID_24561\]

When some OIDs could not be found while retrieving data from an SNMP table, in some cases, all data from that table would incorrectly be dropped and not processed.

#### DataMiner Cube: Icons and names not properly aligned in 'Below this view' list \[ID_24572\]

When you opened a view card and selected *Below this view \> All*, in some cases, the icons and the names of the list items would not be properly aligned.

#### Problem with SLManagedScripting due to a file locking issue \[ID_24586\]

In some cases, an error could occur in the SLManagedScripting process due to a file locking issue.

#### DataMiner Cube - Visual Overview: Shapes linked to elements to which a user had implicit access no longer showed parameter values or alarm colors \[ID_24591\]

In some cases, shapes linked to elements to which a user had implicit access would no longer show any parameter values or alarm colors.

#### DataMiner Cube - Alarms: Severity duration of a history alarm would be displayed incorrectly on the alarm card \[ID_24593\]

When you opened a history alarm in an alarm card, in some cases, the severity duration of that history alarm would be displayed incorrectly.

#### Problem when in a CPE chain field a column was defined instead of a table ID \[ID_24595\]

When, in a CPE chain field, you define a column instead of a table ID, that column will be used as display value instead of the display key.

In some cases, this would no longer work correctly when the rows displayed in a filter box were retrieved by means of a diagram subscription.

#### DataMiner Cube - Data Display: Breadcrumbs of new element, view, service or redundancy group would not include the item itself \[ID_24611\]

When you created a new element, service, view or redundancy group, in some cases, the breadcrumbs displayed at the top of the card would incorrectly not include the object itself.

#### DataMiner Cube - Visual Overview: Not possible to click DCF connection lines when a placeholder was used in the Connection shape \[ID_24618\]

In some rare cases, it would not be possible to click DCF connection lines when a placeholder was specified in the *Connection* shape. Also, connection lines would no longer become transparent when hovering the mouse pointer over them.

#### Module names in SLErrors.txt in upper case \[ID_24626\]

In some cases, it could occur that the DataMiner module names in the SLErrors.txt log file were listed in upper case.

#### Problem during protocol buffer serialization \[ID_24630\]

In some cases, an exception could be thrown during protocol buffer serialization.

#### DataMiner Cube - Data Display: Alarm icon outside of colored background when hovering over a parameter control \[ID_24631\]

When you hovered over a parameter control, in some cases, the colored background would not include the alarm icon.

#### Service & Resource Management: Booking state not updated in services list \[ID_24650\]

In the list of services in the Bookings and Services apps, it could occur that the booking state was not up to date. This information will now be refreshed in real time.

#### Service & Resource Management: Incorrect result when comparing service definitions \[ID_24662\]

If an Automation script compared two service definitions with at least one interface configuration or edge in the diagram, it could occur that the *Equals* method returned false incorrectly.

#### DataMiner Cube - Views: Split view icons would incorrectly display the alarm color of first-level child items as Undefined \[ID_24665\]

When, in the *Settings* window, *View alarm level* was set to “Split”, in some cases, the part of the view icon that has to display the alarm color of the first-level child items would incorrectly display the alarm color associated with the *Undefined* status.

#### DataMiner Cube - EPM/CPE: Problem with chain field option 'statusTabs' \[ID_24668\]

In DataMiner Cube, in some cases, so-called status tab links to pop-up windows (defined in chain field “statusTabs” options) would no longer be rendered correctly.

#### DataMiner Cube: Problem when using TAB to navigate among controls \[ID_24670\]

When you used the TAB key to navigate from one control to another, navigation would fail when a numeric up/down control had the focus.

#### DataMiner Cube - Visual Overview: Cards opened from within a Visio page would not open undocked or in new card \[ID_24675\]

When you opened a card by right-clicking a Visio shape linked to e.g. an element or a view and choosing either *Open ... undocked* or *Open ... in a new card*, in some cases, the card would not open undocked or in a new card.

#### DataMiner Cube - Data Display: DPI settings not always taken into account when rendering selection boxes and tool tips \[ID_24685\]

In Data Display, in some cases, the screen’s DPI settings would not be taken into account when rendering selection boxes and tool tips.

#### Service & Resource Management: Problem when retrieving profile manager data immediately after that data had been updated \[ID_24688\]

When profile manager data (profile parameters, profile instances or profile definitions) was retrieved immediately after that data had been updated, in some cases, old data would be returned.

#### DataMiner Cube: Problem when saving or assigning group settings \[ID_24701\]

In some cases, it would no longer be possible to save group settings or to assign new settings to a group to which none had been assigned before.

#### Jobs app: Action buttons no longer displayed after executing an action \[ID_24710\]

In some cases, after a job action was executed (i.e. creation, editing or deletion of a job), it could occur that the action buttons in the header bar of the panel were no longer displayed.

#### DataMiner Cube: Problem with index/display key column mapping for dynamic column tables \[ID_24722\]

In some cases, the index/display key column mapping for dynamic column tables would be incorrect.

#### Jobs app: Problem with custom time filter \[ID_24726\]

When, in the Jobs app, you set the time filter to “Custom”, in some cases, incorrect timestamps would be used in the job filter.

#### Jobs app: Timeline action buttons displayed in incorrect location \[ID_24732\]

When a job was selected on the timeline in the Jobs app, the action buttons for the job were displayed in the header bar of the app instead of the header bar of the panel.

#### Dashboards app: Resource feed selection lost after refresh \[ID_24738\]

If a resource was selected in a feed, it could occur that the feed did not keep this selection when the page was refreshed.

#### Problem when serial clients went into timeout \[ID_24764\]

When a serial client went into timeout, in some cases, the socket would not be cleaned up correctly, causing the client to not reconnect when the server became available again.

Also, in case of commands that did not require a response, in some cases, the sent data would not be cleaned up correctly, causing the socket to keep on sending.

#### Problem when masking rows or cells in view tables or direct views \[ID_24773\]

In some cases, it would no longer be possible to mask cells or rows in view tables or direct views.

#### DataMiner Cube - Automation: Problem when an Automation script tried to send an e-mail containing a report \[ID_24775\]

In some cases, an error could occur when an Automation script tried to send an e-email containing a report.

#### Problem with SLPort when parsing SSH responses \[ID_24776\]

In some cases, an error could occur in SLPort when parsing SSH responses.

#### Memory leak in SLProtocol \[ID_24793\]

In some cases, SLProtocol could leak memory when communicating with SLPort.

#### Problem when upgrading an entire DataMiner System using DataMiner Taskbar Utility \[ID_24803\]

When you tried to upgrade all agents in a DataMiner System using DataMiner Taskbar Utility, in some cases, an error would appear, saying that it was not possible to connect to SLNet.

#### Problem when masking an entire table \[ID_24805\]

In some cases, it would not be possible to mask an entire table.

Also, the following masking issues have been solved:

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the number of masked alarms (a counter found in the general parameters) would not get incremented.

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the comment in the alarm would incorrectly be set to “Masked by” instead of “Parameter masked by”. As a result, after the element was restarted, the number of masked alarms (a counter found in the general parameters) would incorrectly be doubled.

#### Thread problem in SLDataMiner \[ID_24806\]

When a DataMiner System had a large number of Active Domain users, in some cases, SLDataMiner would use more threads than necessary.

Also, a thread could be leaking memory when DataMiner was unable to connect to the LDAP server.

#### DataMiner Cube - Trending: Problem when saving a trend group \[ID_24875\]

When you saved a trend group after editing it, in some cases, an exception would be thrown and no changes would be saved.

#### Dashboards app: Problem with CPE feed \[ID_24884\]

In some cases, the Dashboards app would become unresponsive after selecting a chain and a field in a CPE feed.

#### Users with an expired password were not able to enter a new password \[ID_24938\]

In some cases, users of whom the password had expired would not be able to enter a new password. Instead, a “Failed to setup ProtoBuf” error would appear.

## Changes in DataMiner 10.0.3 CU1

### CU1 fixes

#### Problem with SLProtocol when calling 'NT_LOAD_TABLE' \[ID_24780\]

In some cases, an error could occur in SLProtocol when calling the NotifyProtocol method “NT_LOAD_TABLE”.

## Changes in DataMiner 10.0.3 CU2

### CU2 fixes

#### Deleting a monitored table row could cause an incorrect alarm to be generated \[ID_24957\]

When a monitored table row was deleted, in some cases, an incorrect alarm with an invalid root ID and invalid time stamp would be generated.

#### Problem with SLDataGateway when installing Indexing Engine \[ID_24969\]

In some cases, an error could occur in SLDataGateway when installing Indexing Engine.

#### CRC trailer from separate IP packet not added to response \[ID_25089\]

If a CRC trailer was returned in a separate IP packet, it could occur that it was not added to the response.
