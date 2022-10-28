---
uid: General_Main_Release_10.3.0_new_features_2
---

# General Main Release 10.3.0 – Other new features (part 2) - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

### DMS web apps

#### Jobs app: Name, Start Time and End Time fields in default job section can now be set read-only [ID_31485] [ID_31506]

<!-- MR 10.3.0 - FR 10.2.1 -->

In the default job section, the *Name*, *Start Time*, and *End Time* fields can now be set read-only.

#### Ticketing app: System name will now be checked for illegal characters [ID_31496]

<!-- MR 10.3.0 - FR 10.2.1 -->

From now on, the system name of a ticket will no longer be allowed to start with an underscore character or contain one of the following characters: . # \* , " '

When the system name contains one of these illegal characters, an error message will appear.

#### Jobs app: Fields will automatically be set to 'not required' when hidden [ID_31513]

<!-- MR 10.3.0 - FR 10.2.1 -->

From now on, when you hide a job field, you will receive a message that it will automatically be set to “not required”.

> [!NOTE]
> When you unhide a hidden field, it will remain set to “not required”.

#### Dashboards app - GQI: Element, service and view data sources now also return an 'In timeout' column [ID_31671]

<!-- MR 10.3.0 - FR 10.2.1 -->

The element, service and view data sources now return an additional “In timeout” column.

| Data source | Meaning of “True” in “In timeout” column |
|--|--|
| Element | The (replication) element is in timeout. |
| Service | One of the elements in the service is in timeout. |
| View | The enhancing element, one of the first-level child elements or one of the recursive child views is in timeout. |

#### Dashboards app: Default index filter for parameter feed component [ID_32595]

<!-- MR 10.3.0 - FR 10.2.4 -->

It is now possible to add a default index filter to a parameter feed component. This way, it's not necessary to apply your filter to the component again whenever the dashboard is refreshed.

This new option is available as an advanced setting that is not displayed by default. To be able to configure it, you therefore first need to add the *showAdvancedSettings=true* option to the dashboard URL. In the *Data* pane of the dashboard edit mode, a new *Parameter table filters* section will then become available. You can configure the default filter in this section and then drag it to a component to apply it.

#### Dashboards app - GQI: Linking feeds to arguments of external data sources [ID_32658]

<!-- MR 10.3.0 - FR 10.2.5 -->

When you build a GQI query that uses an external data source, it is now possible to link feeds to arguments of that external source.

#### Dashboards app: User groups can now be selected in dashboard security [ID_32681]

<!-- MR 10.3.0 - FR 10.2.4 -->

When you configure who can view or edit a specific dashboard, it is now possible to select entire user groups instead of only individual users. Groups are indicated with a different icon to make the difference clear. In the selection box, they are listed together with individual users. Natural sorting is applied, with individual users being sorted by full name and groups being sorted by group name.

#### Dashboards - Data panel: Enhanced element selection [ID_32769]

<!-- MR 10.3.0 - FR 10.2.5 -->

A number of enhancements have been made to the *Elements* section of the Data panel.

Up to now, when you switched to edit mode, the first 10,000 elements would be loaded. From now on, the elements will be loaded in batches and a “Load more” button will allow you to load in the next batch.

Also, there is now an element search box as well as a number of element filter options:

- a view filter to only show elements in a particular view (and its subviews),
- a protocol filter to only show elements running a particular protocol,
- an *EPM managers* checkbox to only show EPM Manager elements, and
- a *Spectrum analyzers* checkbox to only show Spectrum elements.

#### Dashboards app: New sidebar icons to list private and shared dashboards [ID_32854]

<!-- MR 10.3.0 - FR 10.2.7 -->

In the sidebar, next to the *All dashboards* and *Recent dashboards* icons, there are now two new icons:

- *Private dashboards*, and
- *Shared dashboards*.

The first icon will only be available when there are private dashboards, the second icon will only be available when the DataMiner Agent is connected to the cloud and there are shared dashboards.

#### Dashboards app - Service definition component: Arrows will now automatically be drawn when a Process Automation definition was added [ID_32960]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the component will now automatically draw the necessary arrows to indicate the connections between the different blocks/nodes in the diagram.

#### Dashboards app: Using the script output of an interactive Automation script as a feed [ID_32977]

<!-- MR 10.3.0 - FR 10.2.5 -->

When building a GQI query, you can now also use the script output of an interactive Automation script as a feed.

#### Dashboards app - Service definition component: Function shapes will now reflect the function type [ID_32995]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will now reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent).

#### Dashboards app - Service definition component: Function nodes will now display the number of Process Automation tokens in queue or in progress [ID_33025]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, all function nodes will now display the number of tokens currently in queue or in progress.

The token counters will be updated every 10 seconds.

#### Web apps - Data table component: Search box [ID_33385]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you hover over a data table component (e.g. a GQI table), a search box will now appear in the bottom-right corner. When you enter a search string, a case-insensitive client-side search will be performed.

#### Web apps: Dashboards, app pages and app panels now all have a 'Fit to view' setting [ID_33401]

<!-- MR 10.3.0 - FR 10.2.7 -->

In the Dashboards app and the Low-Code Apps, dashboards, app pages, and app panels now all have a “Fit to view” setting that, when enabled, will make sure the items in question are automatically adapted to fit the screen.

#### Web apps - Data table component: Sorting, grouping and filtering options [ID_33403] [ID_33433] [ID_33454]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you right-click a column header of a data table component (e.g. a GQI table), you will now be presented with a number of sorting, grouping and filtering options.

- To sort by the column in question, select a sort order (e.g. A \> Z, Z \> A, etc.).

- To group by the column in question, select *Group*.

- To filter the data in the table, construct a single or composite condition depending on the column type:

    | Column type | Filter option |
    |-------------|---------------|
    | String/GUID | One or more of the following conditions (combined with OR):<br> - contains some text (case insensitive)<br> - does not contains some text (case insensitive)<br> - matches a regular expression<br> - does not match a regular expression<br> - equals some text (case insensitive)<br> - does not equal some text (case insensitive) |
    | Numeric/DateTime | One or more ranges (combined with OR) |
    | Boolean | True or false |

    > [!NOTE]
    >
    > - You can specify multiple column filters. If you do, they will be combined with AND.
    > - Column filters can be used in combination with the component’s search box.
    > - Grouping and column filters are not persistent. When you leave the page, all grouping and filtering will be cleared.

#### Web apps - Data table component: Copy cell/row/column/table [ID_33440]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you right-click a non-empty cell in a data table component (e.g. a GQI table), you can now choose to copy the cell value, the entire row, the entire column or the entire table.

If you choose to copy the entire row or the entire table, the data will be copied in CSV format.

> [!NOTE]
>
> - If you copy a cell or an entire column, the values will not be enclosed in double quotes.
> - If you copy an entire row or an entire table, the values will be enclosed in double quotes.
> - If a value contains double quotes, they will be escaped upon copying.

#### Dashboards app: Service Definition component now supports both types of Process Automation service definitions [ID_33615]

<!-- MR 10.3.0 - FR 10.2.8 -->

The Service Definition component now supports both types of Process Automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### Dashboards app / Low-Code Apps - Service Definition component: Text displayed on Process Automation service definition node will now be the value of that node's Label property [ID_33754]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, when a Service Definition component displayed a service definition of type "Skyline Process Automation" or "Custom Process Automation", the name of the associated function definition would be displayed on the nodes. From now on, the text displayed on a particular node will be the value of that node's *Label* property. Only when no *Label* property could be found will the name of the associated function definition be displayed instead.

#### DataMiner web apps updated to Angular 13 [ID_33869]

<!-- MR 10.3.0 - FR 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 13 instead of Angular 12.

#### GQI: Improved performance when retrieving data [ID_33873] [ID_33890] [ID_33935]

<!-- MR 10.3.0 - FR 10.2.9 -->

Several improvements have been implemented to increase performance when GQI data is requested. At present, the most noticeable change this results in is an increase of the page size when all GQI data is requested. Up to now, when all GQI data was requested, the page size was always set to 50. From now on, the page size will be set to a number between 50 and 1000 based on the number of columns that are retrieved (max. 3000 cells).

#### Dashboards app - GQI: Line & area chart component is now able to visualize GQI query results as a single line [ID_33879]

<!-- MR 10.3.0 - FR 10.2.9 -->

The Line & area chart component is now able to visualize GQI query results as a single line.

1. Add GQI query data to the chart component.

1. In the component settings tab:

   - Select the query.

   - Select the X axis column.

   - Select the Y axis column.

1. In the component layout, adapt the style of the chart.

> [!NOTE]
> If you want the component to show a classic trend chart, make sure the query result is sorted by the X axis column.

#### Dashboards / Low-Code Apps: Parameter table component brought in line with Table component [ID_34132]

<!-- MR 10.3.0 - FR 10.2.10 -->

The *Parameter table* component of dashboards and low-code apps has now been adjusted to be more like that generic *Table* component. In addition to improving consistency between these components, this also makes the *Parameter table* component more user-friendly:

- The horizontal scrollbar is now permanently displayed, while previously you had to scroll all the way to the bottom of the table to see it.
- The table will load more easily, improving performance of the dashboard or app especially with large tables.

Moreover, the additional features of the *Table* component will now also be available for the *Parameter table* component:

- Grouping on one or multiple columns.
- Sorting based on multiple columns.
- Filtering on multiple columns via the column header context menu.
- Filtering using the search box below the table.
- Resizing columns.
- Dragging and dropping columns to change the column order.

> [!NOTE]
> This change does not affect the *Parameter table* component as viewed on mobile devices.

#### GQI: columnInfo object of data source columns of type 'discrete' will now contain the possible values [ID_34179]

<!-- MR 10.3.0 - FR 10.2.10 -->

For each of the following GQI data source columns of type "discrete", the possible values will now be available in their columnInfo object:

| Data source              | Columns |
|--------------------------|---------|
| AlarmAdapter             | Alarm severity<br>Alarm type<br>Alarm status<br>Alarm source<br>Alarm user status |
| BookingAdapter           | Booking status |
| ChangePointAdapter       | Change type<br>Alarm severity |
| DCFInterfaceAdapter      | Interface type |
| LiteElementInfoAdapter   | Element state |
| TicketingAdapter         | All (custom) enum columns |
| DOMInstanceAdapter       | State<br>All custom enum fields |
| ParameterTableAdapter    | All parameters of type "discrete" |
| PaProcessAdapter         | PaProcess state<br>PaProcess activity<br>PaProcess start event type |
| PaTokenAdapter           | PaToken status<br>PaToken error state<br>PaToken sub process type<br>PaToken type |
| PatternOccurrenceAdapter | Pattern type |

#### GQI - EPM feed: Linking 'System Name' and 'System Type' to the query [ID_34222]

<!-- MR 10.3.0 - FR 10.2.10 -->

Using an EPM feed, it is now possible to link *System Name* and *System Type* to the GQI query you are building.

#### Dashboards / Low-Code Apps: Checkboxes to select discrete values in column filter Table component [ID_34234]

<!-- MR 10.3.0 - FR 10.2.9 -->

When you configure a column filter for a Table component in a dashboard or low-code app, you can now select checkboxes to filter on discrete values.

#### GQI: Using GQI query columns to filter a 'State' component [ID_34235]

<!-- MR 10.3.0 - FR 10.2.10 -->

It is now possible to use GQI query columns to filter a *State* component.

#### GQI: Query columns of type 'string' can now be filtered using 'Equals' and 'NotEquals' [ID_34246]

<!-- MR 10.3.0 - FR 10.2.10 -->

Query columns of type "string" can now be filtered using *Equals* and *NotEquals*.

#### Dashboards app / Low-Code Apps: 'Return no rows when feed is empty' option replaced by a triple-state option [ID_34280]

<!-- MR 10.3.0 - FR 10.2.10 -->

Up to now, when configuring the filter of a GQI data feed, you could enable the *Return no rows when feed is empty* option to indicate that, when the feed was empty, you wanted an empty table to be returned instead of the entire table.

Now, this option has been replaced by a triple-state option. You can now indicate that, when the feed is empty, you want

- to have an empty table returned,
- to have the entire table returned, or
- to have the table filtered on empty values.

#### Dashboards app: Filtering a parameter feed that lists EPM parameters [ID_34287]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an EPM identifier from an EPM feed is fed to a parameter feed, it will now be possible to drag multiple parameters onto the parameter feed in order to use them as filters.

#### Web apps - Interactive Automation script components: Minor enhancements [ID_34373]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of minor enhancements have been made to the interactive Automation script components with regard to font styles, button styles, text alignment and button and checkbox height.

#### Dashboards app / Low-Code Apps: GQI queries now support sort operators [ID_34414] [ID_34528] [ID_34479]

<!-- MR 10.3.0 - FR 10.2.11 -->

In dashboards and low-code apps, you can now add sort operators to GQI queries.

After selecting a data source, do the following:

1. Select a *Sort* operator.
1. Select the column to sort on.
1. Select *Ascending* if you want to sort in ascending order instead of descending order.

#### Dashboards app / Low-Code Apps: An eye icon will now appear when you make a modification to a GQI table [ID_34445]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you make one of the following modifications to a GQI table, an eye icon will now appear in the header of the table component.

- Change the sorting
- Apply a grouping
- Change the order of the columns
- Change the width of the columns
- Apply a column filter (using the context menu that appears when right-clicking a column header)

This eye icon will make you aware that the table is no longer identical to the one that was loaded originally. Clicking it will reset all modifications.

#### DataMiner web apps updated to Angular 14 [ID_34447]

<!-- MR 10.3.0 - FR 10.2.11 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 14 instead of Angular 13.

#### Dashboards app / Low-Code Apps: Enhanced filtering by protocol [ID_34453]

<!-- MR 10.3.0 - FR 10.2.11 -->

From now on, when you add a protocol filter to a component without specifying any particular version(s), that filter will return all data related to that protocol irrespective of protocol version. If you want the data in the component to be filtered by a specific version of the protocol in question, you can select that version from the protocol filter box.

#### GQI: New 'IsActive' column added to 'Get alarms' data source [ID_34455]

<!-- MR 10.3.0 - FR 10.2.11 -->

A new *IsActive* column has been added to *Get alarms* data source. This column will be set to true when the alarm is an active alarm.

#### GQI now supports multiple sort in the Table component [ID_34526]

<!-- MR 10.3.0 - FR 10.2.12 -->

When, in the Dashboards app or a web app, you apply multiple sort orders in a *Table* component, multiple sort operators will now be appended to the GQI query that is feeding data to the component.

#### Dashboards app: Parameter feeds that list EPM parameters now allow items to be preselected [ID_34554] [ID_34588]

<!-- MR 10.3.0 - FR 10.2.12 -->

When an EPM feed is used to feed EPM identifiers to a parameter feed, it is now possible to configure filters that will preselect certain items in the parameter feed.

#### Dashboards app: Upload size of PDF files will now be validated [ID_34620]

<!-- MR 10.3.0 - FR 10.2.12 -->

When PDF files are uploaded via the WebAPI (e.g. when a PDF report is generated), an error will now be thrown when the batch size exceeds 10 MB or the total file size exceeds 1 GB.

#### Dashboards app: Items selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard [ID_34622]

<!-- MR 10.3.0 - FR 10.2.12 -->

The parameters and indices selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard.

As a result, the same items will automatically be selected again after you refresh the page.

#### Dashboards app: Parameter indices selected in a parameter feed listing EPM parameters can now be fed to other components [ID_34629]

<!-- MR 10.3.0 - FR 10.2.12 -->

After selecting column parameter indices in a parameter feed listing EPM parameters, you can now feed those selected indices to other components.

#### Dashboards app: Reports will no longer contain visual replacements [ID_34632]

<!-- MR 10.3.0 - FR 10.2.12 -->

Missing information in dashboards is no longer indicated by means of a visual replacement. In PDF reports they are now replaced by a short message.

#### Dashboards app: Jobs and Dashboards app now support PDF module [ID_34634]

<!-- MR 10.3.0 - FR 10.2.12 -->

The PDF module is now available in the Jobs and Dashboards app. From now on, you can e.g. export dashboards to PDF.

#### Dashboards app: PDF and share button will now be hidden in edit mode [ID_34653]

<!-- MR 10.3.0 - FR 10.2.12 -->

The *PDF* and *Share* option in the Dashboards app are now no longer visible in edit mode. Additionally, you can now pin the *Share dashboards* action in the settings menu of the Dashboards app.

#### Dashboards app: Parameter feeds listing EPM parameters now allow parameter grouping [ID_34705]

<!-- MR 10.3.0 - FR 10.2.12 -->

It is now possible to group parameters in a parameter feed that lists EPM parameters.

### DMS Service & Resource Management

#### Retrieving bookings in a paged way and sorted by property [ID_31982]

<!-- MR 10.3.0 - FR 10.2.5 -->

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

#### ProfileInstances: New parameter property 'InheritIsHidden' [ID_32131]

<!-- MR 10.3.0 - FR 10.2.3 -->

In the ParameterSettings property of a profile instance, you can now use the “InheritIsHidden” property to indicate whether a profile instance should inherit the “IsHidden” property of a profile parameter. This property is false by default.

A few examples:

- If a parameter of profile definition A is hidden, and you want profile instance A to inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to true.
- If a parameter of profile definition A is hidden, and you want profile instance B to not inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to false and “IsHidden” to true.

#### ResourceUsageInfoManager [ID_32512]

<!-- MR 10.3.0 - FR 10.2.5 -->

SLNet now includes a ResourceUsageInfoManager, which will keep track of the Resources being used by ReservationInstances. Each time a change is detected as to Resource usage, this manager will send out a ResourceUsageStatusEventMessage containing the DMA ID and a list of UpdatedResourceUsageStatuses.

A ResourceUsageStatus contains a ResourceId and a list of UsingReservationInstances. That list will contain a ReservationInstanceUsageDetails object for every ReservationInstance that is using the Resource. Currently, the object only contains a ReservationInstanceId property.

Normally, a ResourceUsageStatusEventMessage will be sent out the moment a Resource is being used in an ongoing reservation or when a ReservationInstance using that resource ends. When a Resource is no longer used in any reservation, an event will be sent out with a ResourceUsageStatus containing an empty list.

ResourceUsageStatus objects can be retrieved by means of a GetResourceUsageStatusList (FilterElement\<Resource> filter) call on the ResourceManagerHelper. This call will return all status objects for the resources that match the filter and that are currently being used by ongoing reservations.

#### ReservationInstances now have a ReservationInstanceType [ID_32624]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring a ReservationInstance, you now have to specify a ReservationInstanceType:

- Default
- Process Automation
- Custom Process Automation

> [!NOTE]
>
> - In case of a ServiceReservationInstance, the type of the instance must be identical to the type of the ServiceDefinition. Otherwise, the ResourceManager will throw a “ServiceDefinitionTypeDoesNotMatch” error.
> - A new exposer has been added to allow filter ReservationInstanceType.

#### ResourceManagerEventMessage: New LostInterestReservationInstances property [ID_32801]

<!-- MR 10.3.0 - FR 10.2.5 -->

When, for example, a table is populated with ReservationInstances using ResourceManagerEventMessages with a SubscriptionFilter, you can now use the LostInterestReservationInstances property to retrieve the IDs of the ReservationInstances that no longer match the current filter after an update.

> [!NOTE]
> This list will only contain ReservationInstances to which the user has access.
> To retrieve the IDs of the ReservationInstances to which the user no longer has access, you can call the GetHiddenReservationInstances method.

#### Subscribing to ResourceUsageStatusEvents for specific resources [ID_32979]

<!-- MR 10.3.0 - FR 10.2.6 -->

From now on, it is possible to only receive ResourceUsageEventMessages for a specific resource. Using ResourceUsageStatusEventExposers, you can now filter by ResourceId.

#### ReservationInstanceType and ServiceDefinitionType: New values 'ResourceScheduling' and 'ResourceOrchestration' [ID_33390]

<!-- MR 10.3.0 - FR 10.2.7 -->

ReservationInstanceType and ServiceDefinitionType can now be set to the following additional values:

- ResourceScheduling
- ResourceOrchestration

### DMS Mobile Gateway

#### Additional logging after sending a 'send SMS' request to an SMSEagle device [ID_32785] [ID_32911]

<!-- MR 10.3.0 - FR 10.2.5 -->

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

### DMS tools

#### Standalone Elasticsearch Cluster Installer: New RepoPath setting [ID_33055]

<!-- MR 10.3.0 - FR 10.2.6 -->

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

#### QA Device Simulator renamed to Skyline Device Simulator [ID_33680] [ID_34530] [ID_34555]

<!-- RN 33680: MR 10.3.0 - FR 10.2.7 -->
<!-- RN 34530/34555: MR 10.3.0 - FR 10.2.12 -->

The *QA Device Simulator* tool has been renamed to *Skyline Device Simulator* and now targets Microsoft .NET Framework 4.8.

Also, the following command-line parameters have been added:

| Parameters | Function |
|------------|----------|
| `/packetloss <packet loss %>`<br>`/delayms <delay ms>`<br>`/delaypct <delay % of packets>` | Specifying packet loss and packet delay parameters on startup. |
| `/dbmaxvaloid <max nbr of entries per OID>` | Configuring the number of entries loaded in memory per OID when working with database simulations. |

> [!NOTE]
> In the UI of the *Skyline Device Simulator*, the help link now directs you to the *Skyline Device Simulator* help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.
