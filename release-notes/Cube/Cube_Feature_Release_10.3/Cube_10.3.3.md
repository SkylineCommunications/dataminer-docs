---
uid: Cube_Feature_Release_10.3.3
---

# DataMiner Cube Feature Release 10.3.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.3](xref:General_Feature_Release_10.3.3).

## Highlights

#### System Center - Database: Elasticsearch/OpenSearch configuration for Cassandra Cluster setup in Cube [ID_34651]

<!-- MR 10.3.0 - FR 10.3.3 -->
<!-- See General RNs for other change from this RN -->

If a DataMiner System is configured to use a Cassandra Cluster setup (i.e. a setup where one Cassandra cluster is used for the entire DMS), in the *Database* section of System Center, you can now also configure the settings for the Elasticsearch or OpenSearch database:

- Database: *Elasticsearch* or *Elasticsearch/OpenSearch*.
- Database prefix: The name all indices will be prefixed with.
- DB server: The IP addresses or hostnames of the Elasticsearch nodes, or the URL of the Amazon OpenSearch Service endpoint.
- User/Password: The credentials with which the DMA can log on to the database (if applicable).

> [!TIP]
> See also: [OpenSearch & Amazon OpenSearch Service [ID_34651]](xref:General_Feature_Release_10.3.3#opensearch--amazon-opensearch-service-id_34651)

#### Automation: New user/group setting to specify whether users have to confirm program executions launched from interactive Automation scripts [ID_35418]

<!-- MR 10.4.0 - FR 10.3.3 -->

A new user/group setting named *Do not confirm program executions from scripts*, found in the *User > Cube* tab of the *Settings* window, now allows you to specify whether users will have to explicitly confirm each program execution that is launched from an interactive Automation script.

By default, this option will be disabled, meaning that users will have to give their consent each time an interactive Automation script wants to launch a program. The confirmation box will also allow users to change the setting by selecting the *Don't show this confirmation again. Always launch program executions.* checkbox.

Each time a program is launched, a start entry and an end entry will be added to the Cube logging as well as to the *SLClient.txt* log file on the DataMiner Agent.

- The start entry will contain the following data:

  - the name of the Automation script
  - the ID of the Automation script
  - the user's login data (full name, client machine name, client app name and last login date)
  - the program that will be launched
  - the arguments that will be passed to the program (if any)

- The end entry will contain the following data:

  - the user's login data (full name, client machine name, client app name and last login date)
  - the process ID of the program
  - the time at which the process ended
  - the name of the program that ended
  - the arguments that were passed to the program (if any)

## Features

#### System Center - Database: Address specified in the 'DB server' field of a database of type 'Cassandra' or 'CassandraCluster' can now include a custom port [ID_34590]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in the *Database* section of System Center, you are configuring a database of type "Cassandra" or "CassandraCluster", you can now specify an address with a custom port in the *DB server* field.

If you specify a hostname or IP address without a port, DataMiner will fall back to the default Cassandra port 9042.

Examples:

- localhost (Will be resolved to localhost:9042)
- 10.5.100.1:5555

#### Visual Overview - ListView: Copying list data to the Windows clipboard [ID_35170]

<!-- MR 10.4.0 - FR 10.3.3 -->

The ListView component now allows you to copy data from the list to the Windows clipboard.

To copy the contents of one or more rows:

1. Select the row(s).
1. Choose *Copy selected row(s)*.

To copy the contents of a single cell:

1. Right-click in the cell.
1. Choose *Copy \<cell contents\>*.

The data copied to the Windows clipboard is split into a header section and a data section, separated by an empty line. The header section contains the column names, while the data section contains the actual row data.

> [!NOTE]
>
> - Only the columns that are visible to the user will be copied to the Windows clipboard. Also, the order of the columns will be identical to the order of the columns in the ListView component. Note that column visibility and column order can be configured using the component's column manager.
> - When you copy one or more rows, only cells that contain text will be included. For example, cells that only contain a colored rectangle will not be included. Also, when you try to copy the contents of a single cell, the *Copy \<cell contents\>* command will only be available if that cell contains text.

#### System Center: New DataMiner log file 'SLSmartBaselineManager.txt' [ID_35352]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the *Logging* section of *System Center*, you can now also consult the *SLSmartBaselineManager.txt* log file.

## Changes

### Enhancements

#### Tab layout: Click the tab header with the middle mouse button to quickly close a tab [ID_34791]

<!-- MR 10.3.0 - FR 10.3.3 -->

When using the tab layout, up to now, you could quickly close a tab by clicking inside it with the middle mouse button. From now on, to quickly close a tab, instead of clicking inside the tab, you will have to click the tab header with the middle mouse button.

#### Elasticsearch: 'Request Entity Too Large (413)' errors will now be prevented when writing data in bulk [ID_34937]

<!-- MR 10.4.0 - FR 10.3.3 -->

When data was written to Elasticsearch in bulk, up to now, DataMiner would throw a `Request Entity Too Large (413)` error when the amount of data exceeded the 100 MB limit.

From now on, DataMiner will detect when too much data is being sent in a single request and will split up the data into smaller parts.

#### DataMiner Cube will now immediately be aware of any changes as to the availability of Cassandra or Elasticsearch [ID_35209]

<!-- MR 10.3.0 - FR 10.3.3 -->

Up to now, Cube would only check at startup whether Cassandra or Elasticsearch were available. From now on, it will immediately be aware of any changes as to the availability of Cassandra or Elasticsearch.

#### Visual Overview: Leading spaces removed from port information fields [ID_35334]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Leading spaces have been removed from the following port information fields:

- BusAddress
- ElementTimeoutTime
- NrOfRetries
- PollingIP
- SlowPoll
- TimeoutTime

#### EPM: Data retrieved from the collector that was displayed as a table with a single row will now be displayed as single parameters [ID_35371]

<!-- MR 10.3.0 - FR 10.3.3 -->

In an EPM card, in some cases, data retrieved from the collector was displayed as a table with a single row, which often had the system name as primary key.

From now on, data retrieved from the collector that used to be displayed as a table with a single row will now be displayed as single parameters (one for every column).

#### Trending - Pattern matching: A slightly larger number of missing values will now be allowed when you create a trend pattern tag [ID_35376]

<!-- MR 10.4.0 - FR 10.3.3 -->

When you try to create a trend pattern tag, an error message will appear when there are too many missing values in the selected pattern.

From now on, a slightly larger number of missing values will be allowed will you create a trend pattern tag.

#### Trending: Check marks will no longer appear in front of related parameters after adding them to the trend graph [ID_35518]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the top-right corner of a trend graph, a light bulb icon appears when DataMiner finds parameters that are related to the parameters shown in the trend graph. Clicking this light bulb icon allows you to add one or more of those related parameters to the trend graph you are viewing.

Up to now, when you clicked one of those related parameters in order to add it to the trend graph, a check mark would appear in front of it. From now on, check marks will no longer appear in front of related parameters after selecting them.

#### DataMiner Cube - Alarm Console: No longer possible to enable the 'Automatic incident tracking' option for a history tab [ID_35556]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

From now on, it is no longer possible to enable the *Automatic incident tracking* option for a history tab.

### Fixes

#### DataMiner Cube - ListView component: Problem with custom property columns and date columns [ID_35218]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in an *ListView* component, you hovered over a cell value in a custom property column or a date column, no tooltip would appear.

Also, the filter box above a custom property column would incorrectly always be empty.

#### Alarm Console: Multiple values in property columns would incorrectly not be separated by any separator [ID_35239]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

If, in the Alarm Console, property columns are added for service or view properties, and an alarm affects more than one service or view, this can result in property columns containing multiple property values.

In the *PropertyConfiguration.xml* file, for each relevant property you can configure a *contentSeparator* tag. The separator specified in that tag will then be used to separate the values of that property.

Up to now, when a *contentSeparator* tag was left empty, the values of the property in question would incorrect not be separated by any separator. From now on, when that tag is empty, the values of the property in question will by default be separated by commas.

#### Trending: Problem when exporting a trend graph containing average trend data [ID_35290]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you exported a trend graph containing average trend data to CSV, in some cases, the exported data would be parsed incorrectly.

#### ListView component: Column filter boxes incorrectly had autocomplete enabled [ID_35296]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a *ListView* component, you can click the filter icon of a particular column and enter a filter in the box below the column header.

Up to now, those column filter boxes incorrectly had *autocomplete* enabled.

#### Visual Overview: Problem after filtering bookings using a custom time range in ListView component or Resource Manager component [ID_35328]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a ListView component or a Resource Manager component showing a bookings timeline, you had filtered the bookings using a custom time range, performance issues could start to occur after a period of time.

#### Visual Overview: Problem when editing a discrete parameter with a 'Sequence' tag displayed in a lite parameter control [ID_35356]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a discrete parameter with a `<Sequence>` tag was displayed in a lite parameter control, its current value would neither be displayed nor selected while being edited.

#### Data Display: Problem with the alarm bubble-up feature in a tree control containing many-to-many relationships [ID_35367]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a tree control contained many-to-many relationships, up to now, the alarm bubble-up feature would not work correctly.

#### Trending: Pattern matching tags could incorrectly be defined for discrete or string parameters [ID_35368]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

Pattern matching does not support discrete or string parameters. However, up to now, when viewing a trend graph that showed trend information for either a discrete or a string parameter, it would incorrectly be possible to define tags for pattern matching. From now on, this will no longer be possible.

#### Trending: Tag icon was displayed after you selected a section of a trend graph even though it was not possible to define tags [ID_35378] [ID_35383]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, when the pattern matching feature was not enabled in *System Center* > *System settings* > *analytics config*, the tag icon was displayed after you selected a section of a trend graph even though it was not actually possible to define tags.

From now on, Cube will check whether the pattern matching feature is enabled each time you open a trend graph.

#### Data Display: Problem with the alarm bubble-up feature in a tree control containing EPM objects [ID_35396]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a tree control contained EPM objects, in some cases, the alarm bubble-up feature would not work correctly.

#### EPM: Read and write visualization of single-value EPM parameters would incorrectly be displayed both [ID_35416]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

On Data pages, in some cases, the read and write visualization of single-value EPM parameters would incorrectly be displayed both.

From now on, each EPM parameter will only be displayed once. If a write parameter is available, it will be combined with the read parameter.

#### DataMiner Cube - Spectrum analysis: Presets would not be loaded when opening a spectrum element while connected to a heavily loaded DMA [ID_35421]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you opened a spectrum element in a DataMiner Cube that was connected to a heavily loaded DataMiner Agent, the presets would not be loaded.

#### DataMiner Cube - Visual Overview: Problem when filtering bookings in a ListView component [ID_35430]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in Visual Overview, a filter was applied to a *ListView* component that listed bookings, no account would be taken of bookings added after the filter had been applied. As a result, in some cases, the *ListView* component would list bookings that did not match the filter.

#### DataMiner Cube - DCF: Problem when trying to delete a DCF connection in the Properties window of an element [ID_35449]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you tried to remove a DCF connection in the *Properties* window of an element, an exception would be thrown and the connection would not be removed when the destination element was stopped or paused.

#### Visual Overview: Problem when re-arranging dynamically positioned shapes [ID_35462]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a Visio drawing, shapes have been positioned dynamically, you can re-arrange those shapes manually by switching to *Arrange* mode and re-arranging the shapes using drag-and-drop. In some cases, after you had re-arranged a number of shapes, a *NullReferenceException* could be thrown.

#### DataMiner Cube - Visual Overview: Problem when right-clicking a dynamically positioned shape [ID_35463]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a Visio drawing, you were re-arranging dynamically positioned shapes, an exception could be thrown when you right-clicked a shape to access its context menu.

#### Visual Overview: Certain context menu commands would incorrectly be disabled [ID_35484]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you right-clicked a shape, certain context menu commands would incorrectly be disabled.

#### DataMiner Cube - Alarm templates: Trending column in baseline editor would no longer show any icons [ID_35488]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, while configuring an alarm template, you opened the baseline editor and selected the *Automatically update the baseline values* option, the *Trending* column would no longer show an icon when average trending was disabled for the parameter in question.

#### Newly created users would be assigned an invalid full name, description and password when Cube was configured to connect using gRPC [ID_35493]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you had configured DataMiner Cube to connect using gRPC (by specifying `type=GRPCConnection` in the *ConnectionSettings.txt* file), newly created users would be assigned an invalid full name, description and password.

#### Alarm Console: When you clicked a suggestion alarm, the change points and patterns would incorrectly not be loaded [ID_35497]

<!-- MR 10.4.0 - FR 10.3.3 -->

When you clicked a suggestion alarm, in some cases, the trend graph would be loaded but the change points and the patterns incorrectly would not.

#### EPM cards: Collector pages would not be loaded [ID_35523]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you opened an EPM card, in some cases, the collector pages would not be loaded, especially on systems without backend.

From now on, the collector pages will be loaded even when the EPM environment does not include a backend. This will particularly be useful for testing purposes.

#### Trending: Light bulb icon in trend component no longer overlapping [ID_35536]

<!-- MR 10.3.0 - FR 10.3.3 -->

In some cases, the light bulb icon in the top-right corner of a trend graph would incorrectly overlap the full screen or zoom range buttons.

#### DataMiner Cube - Service templates: Open service card would not be updated when the service template was re-applied [ID_35537]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you updated an re-applied a service template while a card of a service created based on that particular service template was open, the data shown on the open service card would incorrectly not be updated.

#### DataMiner Cube - Alarm Console: Alarm counters would start to show negative values when you enabled the 'Automatic incident tracking' option of an active alarms tab while a quick filter was applied [ID_35547]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you enabled the *Automatic incident tracking* option of an active alarms tab while a quick filter was applied, in some cases, the alarm counters in the footer bar would incorrectly start to show negative values.

#### Trending - Parameter relationships: Display keys of suggested parameters would not be correct [ID_35548]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you open a trend graph, a light bulb icon will appear in the top-right corner when DataMiner finds parameters that are related to the parameters shown in the graph. When you click that icon, you get a list of the ten most important parameters, which you can then add to the graph. However, in some cases, the display keys of those listed parameters would not be correct.

#### Trending - Parameter relationships: The same parameter could be added multiple times to the graph when you clicked it repeatedly [ID_35561]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you open a trend graph, a light bulb icon will appear in the top-right corner when DataMiner finds parameters that are related to the parameters shown in the graph. When you click that icon, you get a list of the ten most important parameters, which you can then add to the graph. However, in some cases, when you clicked one of those suggested parameter multiple times, it would incorrectly be added multiple times to the graph.
