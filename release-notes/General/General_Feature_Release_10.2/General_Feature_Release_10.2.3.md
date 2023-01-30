---
uid: General_Feature_Release_10.2.3
---

# General Feature Release 10.2.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### DataMiner Object Model: FieldDescriptors can now be configured to allow multiple values \[ID_31905\]

From now on, the following types of FieldDescriptor can be configured to allow multiple values:

- DomInstanceFieldDescriptor
- ElementFieldDescriptor
- ResourceFieldDescriptor
- ReservationFieldDescriptor
- ServiceDefinitionFieldDescriptor

To make a FieldDescriptor allow multiple values, set its FieldType to “List\<type>”.

- When the FieldType of a FieldDescriptor is set to “List\<type>”, the FieldValue will be the following:

    ```csharp
    Value = new ListValueWrapper<type>(new List<type>...)
    ```

- If you want to add/update the value of a field of which the FieldDescriptor has its FieldType set to “List\<type>”, then use the AddOrUpdateListFieldValue method. The AddOrUpdateFieldValue method can only be used to add or update fields with a single value.

> [!NOTE]
> The Jobs app currently does not support using FieldDescriptors of which FieldType is set to “List\<type>”.

#### DataMiner Object Model: DomInstanceValueFieldDescriptor \[ID_32326\]

A new field descriptor is now available: DomInstanceValueFieldDescriptor

This field descriptor can be used to define a field that will contain the ID of a DomInstance. However, compared to the DomInstanceFieldDescriptor, this descriptor also references a specific value of that DomInstance.

The configuration of this new descriptor is identical to that of the DomInstanceFieldDescriptor, apart from a FieldDescriptorId property, which references a specific FieldValue.

### DMS Protocols

#### Elasticsearch: Defining a logger table of type DirectConnection with a primary key \[ID_32375\]

It is now possible to define a logger table of type DirectConnection with a primary key.

In the \<Param> element of the logger table, do the following:

- Set ArrayOptions\@index to “1”.
- In Database, Set IndexingOptions@enabled to “true” and Connection.Type to “Directconnection”.

See the following example:

```xml
<Param>
  <ArrayOptions index="1" options=";database" ...>
    ...
  </ArrayOptions>
  <Database>
    <IndexingOptions enabled="true" />
    <Connection>
      <Type>Directconnection</Type>
    </Connection>
  </Database>
</Param>
```

##### Overview of the possible ArrayOptions\@index and Connection.Type combinations

- Connection type: DirectConnection

  - No index defined: The data will be pushed via the direct connection and the ID will be assigned by the database. Updating the data will not be possible in this case.
  - Index defined: The data will be pushed via the direct connection and the ID will be assigned by the column template that is being sent via the direct connection by means of an “InitializeWriteAction”.

  > [!NOTE]
  > When using directconnection in combination with a defined index, the TTL of the table should always be infinite.

- Connection type: SLProtocol

  - No index defined: Currently not supported.
  - Index defined: Default logger table configuration.

- No connection type defined

  - No index defined: Fallback to connection type “DirectConnection” with no index defined.
  - Index defined: Fallback to connection type “SLProtocol” with index defined.

### DMS Cube

#### System Center - Users/Groups: Renamed user permissions \[ID_32141\]

For reasons of consistency, the following user permissions have been renamed:

| Old name                                     | New name                                |
|----------------------------------------------|-----------------------------------------|
| Best practices analyzer \> Read              | Best practices analyzer \> UI available |
| Alarm templates \> Add alarm templates       | Alarm templates \> Add                  |
| Alarm templates \> Edit alarm templates      | Alarm templates \> Edit                 |
| Alarm templates \> Delete alarm templates    | Alarm templates \> Delete               |
| Trend templates \> Configure trend templates | Trend templates \> Configure            |

#### Visual Overview: Resource placeholder can now be used to check whether a resource is in use \[ID_32203\]

The \[Resource:...\] placeholder can be used to retrieve a property of a resource. From now on, it can also be used to check whether a resource is being used by any bookings. To do so, use the following syntax.

```txt
[Resource:<GUID>,InUse]
```

> [!NOTE]
> Currently, this check will only be performed when the visual overview is opened or when the GUID or the resource itself is changed.

See also: [New “IN USE” info tag to be used in element shapes linked to resources \[ID_32393\]](#new-in-use-info-tag-to-be-used-in-element-shapes-linked-to-resources-id_32393)

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

#### Visual Overview: Linking a shape to an alarm filter with a System Name filter context \[ID_32252\]

When you link a shape to an alarm filter, you can specify a filter context. Up to now, it was possible to filter on element, service or view. Now, it is also possible to filter on EPM system name using the following syntax:

```txt
FilterContext=SystemName=X
```

If you specify a filter context like the one above, the shape will be linked to the alarms of which the “System Name” property is set to “X”. This will allow you, for example, to show the alarm statistics of an EPM object or to create a new alarm tab by clicking the shape in question.

#### Visual Overview: Use of dynamic units now depends on value of DynamicUnits soft-launch option \[ID_32256\]

Up to now, when configuring a parameter shape, it was possible to enable to use of dynamic units (i.e. units that can be converted to other units according to rules configured in the protocol) by adding “DynamicUnits=true” in an Options data field. From now on, when you do not specify this option in a parameter shape, whether or not that shape will use dynamic unit will depend on the value of the DynamicUnits soft-launch option.

> [!NOTE]
> The DynamicUnits=true/false option can now be used to override the value of the DynamicUnits soft-launch option. For example, if the DynamicUnits soft-launch option is set to true, you can configure a parameter shape to not use dynamic units by adding "DynamicUnits=False" to its Options data field.
>
> For more information on soft-launch options, see [Soft-launch options](xref:SoftLaunchOptions).

#### Data Display: Support for launching EPM objects by clicking buttons in Data Display table cells \[ID_32368\]

This feature offers a new way of adding links to EPM objects in a Data Display table.

When, in a protocol, you configure a cell button as shown below, the table cell will display the SystemType and SystemName defined in the EPM object. Clicking the link will open a new card for that object.

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

The discreet value can contain the SystemType and SystemName of the object, or a reference like “{pid:530}”. In the example above, the identifier is stored in the column with parameter ID 530, which can be the read parameter of the same column or a different column.

If you know the type of the EPM object, you can add a type prefix (epm or view), followed by an equal sign and (a reference to) the identifier.

The \<Display> tag of the discreet can contain the same references as the \<Value> tag. One extra keyword is possible (and recommended): {linkedItemName}. This keyword will be replaced with the name of the object referred to in the \<Value> tag.

If you want to specify the page to be selected by default, add a suffix to the identifier in the \<Value> tag containing the root page name and the page name, separated by a colon. See the following examples:

- EPM=Cable/SF Cable1:Topology:Total
- VIEW=436:BelowThisObject:STB
- VIEW=436:BelowThisView:Elements

> [!NOTE]
>
> - In each of the examples above, the card will be opened on a particular page:
>   - “Topology:Total” or “t:Total” will open the topology page named “Total”.
>   - “BelowThisObject:STB” or “bto:STB” will open the CPE card page named “STB”.
>   - “BelowThisView:Elements” or “btv:Elements” will open the view card page named “Elements”.
> - When the card layout is set to “Tab layout”, it is now possible to save EPM cards in workspaces.

#### New 'IN USE' info tag to be used in element shapes linked to resources \[ID_32393\]

Shapes that are linked to an element can automatically be linked to corresponding resources by adding “UseResource=True” in a shape data field of type Options.

From now on, in shapes linked to resources, you can specify “IN USE” in a shape data field of type Info. That way, the shape will indicate whether the linked resource is in use. However, note that for this feature to work, the shape text has to contain a “\*” character.

Alternatively, you can also use “\[In use\]” in any dynamic part specified in either a shape data field or the shape text.

See also: [Visual Overview: Resource placeholder can now be used to check whether a resource is in use \[ID_32203\]](#visual-overview-resource-placeholder-can-now-be-used-to-check-whether-a-resource-is-in-use-id_32203)

#### Visual Overview: Text wrapping and trimming \[ID_32440\]

In shapes linked to an object, it is now possible to change the text wrapping and trimming.

To do so, add a shape data field of type TextStyle, and set its value to “TextWrapping=...” and/or “TextTrimming=...” (separated by a pipe character).

| Shape data field | Value                                                                                       |
|------------------|---------------------------------------------------------------------------------------------|
| TextStyle        | TextWrapping=NoWrap/Wrap/WrapWithOverflow\|TextTrimming=CharacterEllipsis/WordEllipsis/None |

##### TextWrapping options

- **NoWrap**: The text will not wrap onto a new line, unless one was explicitly configured with a line break. Text that exceeds the bounds of the shape width and/or height will not be shown.

- **Wrap**: The text will automatically be wrapped onto new lines when the width of the shape is exceeded. The text past the boundaries of the shape height will not be shown.

- **WrapWithOverflow**: The text will be shown as before (default option).

##### TextTrimming options

- **CharacterEllipsis**: The text will be cut off a bit earlier than when TextTrimming is set to “None”, and “...” will be added to indicate that the text is longer than what fits in the shape.

- **WordEllipsis**: The text will be cut off at the nearest full word, and “...” will be added to indicate that the text is longer than what fits in the shape.

- **None**: The text will be cut off when necessary (default option).

> [!NOTE]
> Setting TextTrimming to either “CharacterEllipsis” or “WordEllipsis” will have no effect when TextWrapping is set to its default value (i.e. “WrapWithOverflow”).

### DMS Reports & Dashboards

#### Dashboards app - Line chart component: New 'Trend points' setting \[ID_31751\]

When configuring a line chart component, you can now indicate how trend data points should be added to the graph by setting the *Trend points* option to one of the following values:

- Average (changes only) (default value)
- Average (fixed interval)
- Real-time

This setting will also be taken into account when you export a trend graph to a CSV file.

#### Visual Overview - Embedded Resource Manager component: SelectedTimeRange variable will now be cleared when you select another time range in the timeline \[ID_32394\]

When you select a time range in an embedded Resource Manager component, that range will be stored in the SelectedTimeRange variable. Up to now, this variable was cleared whenever you selected a resource item. From now on, it will cleared when you select another time range in the timeline.

### DMS Service & Resource Management

#### ProfileInstances: New parameter property 'InheritIsHidden' \[ID_32131\]

In the ParameterSettings property of a profile instance, you can now use the “InheritIsHidden” property to indicate whether a profile instance should inherit the “IsHidden” property of a profile parameter. This property is false by default.

A few examples:

- If a parameter of profile definition A is hidden, and you want profile instance A to inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to true.
- If a parameter of profile definition A is hidden, and you want profile instance B to not inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to false and “IsHidden” to true.

#### Replacing system functions by uploading an XML file \[ID_32264\]

It is now possible to replace the system protocol functions by uploading an XML file using the ProtocolFunctionHelper. See the following example.

```csharp
var pfHelper = new ProtocolFunctionHelper(engine.SendSLNetMessages);
var xmlContent = File.ReadAllText("...");
pfHelper.ReplaceActiveSystemFunctionDefinitions(xmlcontent);
```

> [!NOTE]
>
> - If the uploaded file is not a valid XML file, a DataMinerException will be thrown and the system functions will not be replaced.
> - Each function in the XML file must have a valid ID. Functions without a valid ID will be ignored.

## Changes

### Enhancements

#### Security enhancements \[ID_31045\] \[ID_31054\] \[ID_32125\] \[ID_32055\]

A number of security enhancements have been made.

#### SLElement: Enhanced performance when working with tables using the 'naming' or 'namingformat' option \[ID_30973\]

Due to a number of enhancements, overall performance of SLElement has increased, especially when working with tables using the “naming” or “namingformat” option.

#### OpenSSL libraries updated to version 1.1.1l \[ID_31977\]

The OpenSSL libraries in DataMiner have been updated to the latest version (v1.1.1l).

#### Behavioral anomaly detection: Change point flood notice will now be cleared sooner \[ID_32013\]

From now on, the notice created when the rate of newly detected behavioral changes reaches an upper limit will be cleared sooner. It will now be cleared when the rate has dropped under the limit again and there is no new flood situation in the following 15 minutes. Up to now, the notice would not be cleared for at least 2 hours, even when the actual flood situation had only lasted for a few seconds.

The notice will contain the following message:

```txt
Detection of behavioral anomalies temporarily disabled on DMA ...: maximum allowed rate of behavioral change points reached.
```

#### SLElement: Enhanced performance when processing partially included services \[ID_32080\]

Due to a number of enhancements, overall performance of SLElement has increased when processing partially included services.

#### DataMiner Cube - Services app: Enhanced performance \[ID_32082\]

Due to a number of enhancements, overall performance has increased when opening the Services app and when updating data in the services list.

#### SLElement: Enhanced performance when processing alarms \[ID_32111\]

Due to a number of enhancements, overall performance of SLElement has increased when processing alarms.

#### SLElement: Enhanced performance when working with DCF interfaces \[ID_32126\] \[ID_32127\]

Due to a number of enhancements, overall performance of SLElement has increased when working with DCF interfaces.

#### Enhanced performance when connecting to a system with a large number of LDAP users \[ID_32146\]

Due to a number of enhancements, overall performance has increased when connecting to a system with a large number of LDAP users.

#### Start window of DataMiner Cube desktop app now has a look and feel that is identical to that of the other Cube apps \[ID_32161\]

The start window of the DataMiner Cube desktop app has now been adapted so that its overall look and feel is identical to that of the other Cube apps.

#### Logging at element startup has been optimized \[ID_32172\]

Logging at element startup has been optimized.

#### Embedded Chromium web browser engine updated to v96 \[ID_32194\]

The embedded Chromium web browser engine in DataMiner Cube has been updated from v81 to v96. This also updates the engine used to generate PDF reports and prevents a possible issue where browser controls would stop rendering after a switch between card tabs.

In addition, when Cube downloads and installs the Chromium engine from the DMA, it will now verify the integrity of the download file.

#### DataMiner Cube - Resources app: Enhanced performance when loading the resource pools and resources \[ID_32211\]

Due to a number of enhancements, overall performance has increased when loading all resource pools and resources after opening the Resources app.

#### Enhanced smart-serial client throughput \[ID_32219\]

Due to a number of enhancements, the overall throughput of smart-serial clients has increased.

#### Elasticsearch: Enhanced data retrieval \[ID_32240\]

A number of enhancements have been made with regard to the retrieval of data stored in Elasticsearch databases.

#### Failover: Enhanced logging \[ID_32265\]

Failover logging has been reviewed. All relevant logging related to switching and Failover setup was moved to INF\|0, ERR\|0 or CRU\|0.

#### SLAnalytics - Alarm focus: Enhanced performance \[ID_32270\]

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time. Due to a number of enhancements, overall performance of this alarm focus feature has increased.

#### SNMPAgent: Enhanced error handling \[ID_32276\]

A number of enhancements have been made to the SLSNMPAgent process, especially with regard to error handling.

#### DataMiner Cube - System Center: Enhanced performance when opening the Users/Groups section \[ID_32307\]

Due to a number of enhancements, overall performance has increased when opening the Users/Groups section of System Center.

#### DataMiner Cube: Enhanced performance when reloading protocols after a protocol update \[ID_32315\]

Due to a number of enhancements, overall performance has increased when reloading protocols after a protocol update.

#### Dashboards app: Enhanced performance when retrieving parameter data from elements and services \[ID_32340\]

Due to a number of enhancements, overall performance has increased when retrieving parameter data from elements and services.

#### Web Services API: Web socket interface will now handle incoming messages asynchronously \[ID_32390\]

Up to now, when clients sent messages to the web socket interface of the Web Services API, those message were handled synchronously. From now on, the web socket interface will handle all incoming messages asynchronously.

#### SLAnalytics: A notice event will no longer be generated when entering change point flood mode \[ID_32402\]

Up to now, a notice event would be generated whenever SLAnalytics had entered change point flood mode. From now on, this event will no longer be generated.

> [!NOTE]
> As before, an entry will be added to the SLAnalytics log whenever behavioral anomaly detection has temporarily been disabled because change point flood mode was activated.

#### NATS cluster will now update itself automatically \[ID_32424\]

When a DataMiner Agent joins or leaves an existing DataMiner System or when a Failover configuration is set up or ended, from now on, the NATS cluster will automatically update itself.

#### Message throttling no longer applied for spectrum traces \[ID_32426\]

As spectrum traces are intended to mimic the actual front-panel display of a spectrum analyzer, message throttling is now no long applied to parameter changes originating from SLSpectrum.

#### DataMiner Cube: Skyline Black theme now features improved support for function icons \[ID_32430\]

The Skyline Black theme now features improved support for function icons.

#### Enhanced performance when uploading DataMiner upgrade packages \[ID_32597\]

Due to a number of enhancements, overall performance has increased when uploading DataMiner upgrade packages.

#### DataMiner Object Model: DomActionError class now marked as serializable \[ID_32615\]

The DomActionError class has now been marked as serializable.

### Fixes

#### DataMiner Cube: When opening an email report, certain parameters would not be loaded correctly \[ID_31969\]

When you created an email report in Scheduler, Automation or Correlation, and then added a number of parameters to it, in some rare cases, some of those parameters would not be loaded correctly when you reopened Scheduler, Automation or Correlation.

#### DataMiner Cube: Trend graph of a parameter updated via history sets would be drawn incorrectly \[ID_31994\] \[ID_32001\]

Up to now, the trend graph of a parameter updated via history sets would be drawn incorrectly. From now on, for history set parameters, the line indicating parameter updates will no longer be drawn up to the current time. Instead, it will be drawn up to the time of the last parameter update.

#### Service & Resource Management: Retrieving ReservationInstances sorted by a property of type string would return an incorrectly sorted result set \[ID_32003\]

When a list of ReservationInstances were retrieved sorted by a property of type string, that list would be returned in an incorrect sort order.

#### Dashboards app: Problems with GQI \[ID_32142\]

In the Dashboards app, a number of issues with regard to GQI have been resolved.

- Column manipulation by regular expression would not work when all columns contained numeric values.
- Column manipulation by concatenation would concatenate the raw values instead of the display values.
- When data was being aggregated, “group by” operations would use the raw value instead of the display value.

#### Dashboards app: Problem when double-clicking the 'Start editing' button \[ID_32159\]

When, in the Dashboards app, you double-clicked the *Start editing* button, in some cases, the dashboard would keep on going in and out of edit mode.

#### Failover: MigrationManager and ProfileManager exceptions could be thrown when setting up a Failover system without an ElasticSearch database \[ID_32163\]

When a Failover system was set up without an ElasticSearch database, in some cases, BaseProfileManager and MigrationManager exceptions could appear in the Alarm Console.

#### Automation: Minor fixes with regard to the generation of email reports via Dashboards app \[ID_32165\]

In Automation, a number of minor issues have been fixed with regard to the generation of email reports via the Dashboards app.

#### Service & Resource Management: A GetResources call with a filter applied could return different results depending on the software license \[ID_32168\]

A GetResources call with a filter applied could return different results depending on the software licenses found on the system (Resource Manager license but no IDP License, or vice versa).

#### Problem when stopping or removing elements belonging to an enhanced service \[ID_32175\]

In some cases, an error could occur in SLProtocol when stopping or removing elements belonging to an enhanced service.

#### Parent EPM item unmasked while still containing masked sub-items \[ID_32179\]

When a specific EPM item was masked for a period of time and then got unmasked, it could occur that its parent EPM item was also unmasked even though it still contained other masked EPM sub-items.

Now an EPM item can only be unmasked if all underlying items are unmasked. When an EPM sub-item cannot be unmasked for some reason, this will be logged in the SLNet logging. In addition, when you mask an EPM item and some of its sub-items cannot be masked, only the sub-items that were masked will be considered to be masked together with the EPM item, and the failures will be logged in the SLNet logging.

#### Problem with SLAnalytics due to a stack overflow exception \[ID_32190\]

In some cases, an error could occur in the SLAnalytics process due to a stack overflow exception.

#### DataMiner Cube - Alarm Console: 'Audible alert' option was not saved correctly when an alarm tab was added to a workspace \[ID_32191\]

When you undocked an alarm tab in which the “audible alert” option was selected, and then saved the workspace, the “audible alert” option would not be saved correctly.

#### DataMiner Cube: Certain shortcut menu items would not be displayed when the UI language was set to a language other than English \[ID_32196\]

In some cases, certain shortcut menu items would not be displayed when the UI language was set to a language other than English.

#### SLLogCollector would not start up when SLWatchDog2.txt or SLElementsInProtocol.txt were missing \[ID_32205\]

At startup, the SLLogCollector tool checks for issues by reading the SLWatchDog2.txt and SLElementInProtocol.txt log files. Up to now, it would not start up when it was unable to find those files. From now on, when SLLogCollector does not find the above-mentioned log files, it will notify the user but start up correctly.

#### DataMiner Cube - Alarm Console: Making an alarm tab show history alarms instead of active alarms would cause the name of the alarm tab to be updated incorrectly \[ID_32215\]

When you created an “active alarms” tab for a certain object (element, service or view) by dropping that object onto the Alarm Console, and then made the tab show history alarms instead of active alarms, the automatically generated tab name was incorrectly set to “Alarms of the last 0 hours” instead of “\~Last hour (up till X)”.

#### DataMiner Cube - Alarm Console: Not possible to change the 'Automatic incident tracking' option in an alarm tab that was enforced by group settings \[ID_32218\]

In an alarm tab that was enforced by group settings, up to now, it would not be possible to change the “automatic incident tracking” option.

#### Problem with SLPort when stopping an element with a serial or smart-serial connection \[ID_32221\]

In some cases, an error could occur in SLPort when an element with a serial or smart-serial connection was stopped.

#### Web apps: All CSS styles would incorrectly be reloaded when the theme colors were updated \[ID_32231\]

When, in a web app, the theme colors were updated, up to now, all CSS styles would incorrectly be reloaded.

#### DataMiner Cube: Aggregation rule values were displayed with too many decimals \[ID_32235\]

In some cases, aggregation rule values were displayed with too many decimals.

#### DataMiner would incorrectly try to connect to 127.0.0.1 when taking a backup of a Cassandra database \[ID_32242\]

When a DataMiner backup included a backup of a Cassandra database, and, in the Cassandra.yml file, the rpc_address setting did not contain “0.0.0.0”, DataMiner would incorrectly assume the database was located at IP address 127.0.0.1. From now on, DataMiner will instead connect to the database located at the IP address specified in the DB.xml file.

#### Dashboards app: Feeds would stop feeding data after refreshing the page \[ID_32251\]

In some cases, feeds in a dashboards would stop feeding data after refreshing the page.

#### Problem with SLXml at DataMiner startup \[ID_32255\]

At DataMiner startup, in some rare cases, an error could occur in the SLXml process.

#### Dashboards app: Parameter state component would not show parameter updates for certain column parameters when using table index filters \[ID_32268\]

When a parameter state component was linked to a column parameter from a table using display keys and filtered using a table index filter, the data displayed by that component would not be updated when changes were made to the parameter.

#### Dashboards app: GQI engine would not fall back to the timezone of the browser when the commonServer.ui.DefaultTimeZone setting could not be found \[ID_32283\]

From DataMiner 9.6.11 onwards, the DataMiner web apps format time values based on the commonServer.ui.DefaultTimeZone setting, located in the C:\\Skyline DataMiner\\Users\\ClientSettings.json file. When this setting cannot be found, they will instead use the time zone of the browser. Up to now, the GQI engine would incorrectly not fall back to the time zone of the browser when it was unable to find the commonServer.ui.DefaultTimeZone setting in the ClientSettings.json file.

#### DataMiner Cube - Visual Overview: Problem when navigating inside EPM cards \[ID_32288\]

When working inside an EPM card, in some cases, it would no longer be possible to navigate to a data page or a subpage.

#### DataMiner Cube - Alarm Console: Alarm status no longer updated when alarms were grouped by service \[ID_32294\]

When, in an alarm tab, the alarms were grouped by service, in some cases, the status of alarms that affected at least two services for which no alarms existed at the moment the alarms were grouped would no longer be updated.

#### Service & Resource Management: SRM operations could fail due to connection issues between agents \[ID_32296\]

In some cases, SRM operations like creating or updating bookings and creating or updating resources could fail due to connection issues between the different agents.

#### DataMiner Cube: Problem when a user without permission to view service definitions connected to an SRM system \[ID_32309\]

When a user connected to a Service & Resource Management environment, DataMiner Cube would throw an exception when that user did not have permission to view service definitions.

#### Problem when opening DMS Alerter \[ID_32312\]

In some cases, an error could occur when you opened DMS Alerter.

#### Dashboards app: Shared dashboards could lose their web socket connection \[ID_32321\]

In some cases, shared dashboards could lose their web socket connection after a period of inactivity. From now on, clients will send a heartbeat message every 30 seconds to keep the connection alive.

#### Dashboards app: Parameter feeds would incorrectly not load all parameter indices \[ID_32329\]

When loading parameters, in some cases, a parameter feed would incorrectly not load all parameter indices.

#### SLDataGateway would incorrectly try to start the local Cassandra service when a remote Cassandra cluster was configured \[ID_32338\]

In some cases, SLDataGateway would incorrectly try to start the local Cassandra service in situations where a remote Cassandra cluster was configured.

#### Cassandra: Problem when a NULL value was encountered in a logger table during a database migration \[ID_32358\]

When migrating a database to a Cassandra cluster, in some cases, an error could be thrown when a NULL value was encountered in a logger table.

#### Incorrect service impact alarms after disabling and enabling a virtual function \[ID_32359\]

When a virtual function was disabled and then enabled again, in some cases, the alarms that affected the function would incorrectly affect a deleted service.

#### Failover: Problem when using a shared hostname instead of a virtual IP address \[ID_32362\]

When a Failover system used a shared hostname instead of a virtual IP address, in some cases, the agents would not be able to connect using IPv6 addresses.

#### DataMiner Cube - Visual overview: Problems with path highlighting \[ID_32364\]

The following issues with regard to connection highlighting have been fixed:

- In some cases, paths of connectors without a matching DCF connection would no longer be highlighted. Only shapes and lines that were linked directly would be highlighted.

- Clicking a non-linked shape that was part of a path would no longer cause that path to be highlighted.

    > [!NOTE]
    > If a non-linked shape in a path has shape text and you want it to be highlighted when clicked, then make sure to add a shape data field of type Enabled to it to and set that field to “False”. This will disable the “copy text” command in the shape’s shortcut menu command and make sure the shape can be highlighted.

#### Problem when retrieving trend data in the Monitoring app \[ID_32366\]

In some cases, it was no longer possible to retrieve trend data in the Monitoring app due to a parsing problem in GetParameterResponseMessage and GetAlarmStateResponseMessage.

#### DataMiner Cube - Visual Overview: Card buttons in an EPM card would no longer work when the Topology sidebar was selected \[ID_32372\]

When an EPM card was opened from a visual overview, and the Topology tab was selected in the sidebar, a number of buttons inside that EPM card would no longer work.

#### DataMiner Cube - Visual Overview: DCF connectivity not loaded when opening a Visio page embedded in another Visio page \[ID_32377\]

Up to now, when a Visio page was opened, the DCF connectivity would incorrectly not be loaded when that Visio page was embedded in another Visio page.

#### DataMiner Cube - Profiles app: Problem when duplicating profile parameters with mediation snippets \[ID_32387\]

When you duplicated a profile parameter with a mediation snippet on one of the configured protocol links, the duplicated mediation snippet would incorrectly not be marked as new. As a result, that snippet would not get added.

#### DataMiner Cube - Alarm Console: Newly created private alarm filter would not be automatically selected in the filter selection box \[ID_32401\]

When, in the Alarm Console, you created a new private alarm filter, in some cases, that new filter would not automatically be selected after saving it. The filter selection box would incorrectly show “\<Click to select>” instead of the name of the newly created filter.

#### Spectrum Analysis: Presets not saved/loaded correctly in spectrum card launched from spectrum thumbnail \[ID_32404\]

When a spectrum element card is launched from a spectrum thumbnail in Visual Overview, it is displayed in buffer mode. Up to now, in this buffer mode, markers, reference lines, and thresholds were not taken into account when presets were saved or loaded. These will now be included. Note that the initial preset content checkboxes will be different in this buffer mode compared to the regular spectrum analyzer mode.

#### SLAnalytics: Automatic incident tracking would not start up when an alarm was cleared during the startup routine \[ID_32408\]

In some cases, automatic incident tracking would not start up when an alarm was cleared during the startup routine.

#### SLAnalytics: Problem with alarm grouping when alarms were generated while automatic incident tracking was starting up \[ID_32410\]

When alarms were generated while automatic incident tracking was starting up, in some cases, an alarm could internally be duplicated, leading to incorrect alarm groups (e.g. groups containing only a single alarm).

#### DataMiner Cube - Alarm Console: Problem with 'new alarms' counter when alarms were grouped by service \[ID_32427\]

When, in an alarm tab in which the alarms were grouped by service, an alarm affecting at least two services was cleared, then the “new alarms” counter in the tab header would show an incorrect number of alarms.

#### DataMiner Cube: Properties not shown in the Surveyor \[ID_32429\]

In some cases, properties with the “Display this property in the Surveyor” option enabled would incorrectly not be displayed in the Surveyor.

From now on, when you create a new property and enable its “Display this property in the Surveyor” option, it will immediately show up in the Surveyor, and when you enable that option for an existing property, the property will show up in the Surveyor the first time its value is updated or the next time the user logs in.

When users enable the option for an existing property, a tooltip will now inform them that the value will only appear after logging off and logging in again.

#### Alerter: Sound files not loaded correctly \[ID_32431\]

In some cases, the sound files configured in Alerter could not be loaded correctly to the client, so that these no longer worked.

#### Failover: Problem with SLDataGateway after losing its connection to SLNet during a Failover switch \[ID_32435\]

When a Failover switch is performed, in some cases, SLDataGateway loses its connection to SLNet and immediately recreates it. However, because it did not receive any SLNet events during the time the connection was lost, up to now, SLDataGateway would be unaware that DataMiner was up and running, causing all write operations that require information from SLNet to get blocked. From now on, as soon as the connection between SLNet and SLDataGateway is re-established, the latter will assume DataMiner is up and running.

#### A large number of CRequest::Request errors would be logged when elements were stopped \[ID_32444\]

When elements were stopped, in some cases, a large number of CRequest::Request errors would be logged.

#### Dashboards: Component selection not cleared when switching between dashboards \[ID_32452\]

In some cases, component selection was not cleared when you switched between different dashboards in the Dashboards app, which could cause issues when new components were added.

#### Not possible to create element with invalid XML character in name \[ID_32455\]

In some cases, it was no longer possible to create elements with an invalid XML character in the element name, even if that character was supported in Cube (e.g. “&”).

#### DataMiner Cube: Problem when accessing an information template, a trend template or an alarm template from within the Alarm Console \[ID_32457\]

In the Alarm Console, you can right-click an alarm and select *Change \> Information*, *Change \> Trending* or *Change \> Alarm range* to access the information template, the trend template or the alarm template for the parameter associated with the alarm. In some rare cases, you could only do so once. When you tried to access an information template, a trend template or an alarm template a second time by right-clicking *Change \> Information*, *Change \> Trending* or *Change \> Alarm range*, a blank window would incorrectly appear.

#### Web apps: Menu would not close after selecting the same option twice \[ID_32461\]

After selected the same menu option twice, the menu would not close until you clicked somewhere else on the page.

#### SLAnalytics: Pattern matching would no longer work due to a problem while retrieving pattern data from Elasticsearch \[ID_32466\]

In some cases, pattern matching would no longer work due to a problem while retrieving pattern data from the Elasticsearch database.

#### Pinned state of alarm tab cards not included in workspace \[ID_32471\]

When a workspace was saved, the pinned state of alarm tab cards was not included.

#### DataMiner Cube - Visual Overview: Problem with initial page selection \[ID_32527\]

When you assign a Visio drawing to a view or a service, you can specify a default page. This initial page selection would no longer work.

Also, when the *How to show element card Data pages* setting was set to “Show in drop-down box”, initial page selection would no longer work.

#### Web apps: 'Refresh now' message would incorrectly appear when opening a web app that did not have an active websocket connection \[ID_32585\]

When your opened a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) that did not have an active websocket connection, a “Refresh now” message would incorrectly appear. From now on, this message will only appear when an active websocket connection was broken.
