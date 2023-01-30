---
uid: General_Feature_Release_10.0.8
---

# General Feature Release 10.0.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Less open IP ports needed when installing DataMiner with a Cassandra database \[ID_25833\]

When installing DataMiner with a Cassandra database, up to now, IP ports 7000, 7001, 7199, 9042, 9142 and 9160 needed to be open. From now on, only ports 7000 and 9042 will need to be open.

#### A notice will now be generated when elements or services with identical names are found in the DMS \[ID_25899\]

When elements or services are created on agents of the same DMS while those are not able to synchronize due to connection issues, it can happen that elements or services are created with identical names. From now on, as soon as the connection between disconnected agents is restored, the agent with the lowest DMA ID will generate a notice when it finds elements or services with identical names.

### DMS Security

#### User management: Domain attribute of DataMiner users will now be filled in with the NETBIOS name if it can be found in the LDAP \[ID_25876\]

From now on, DataMiner users will have their domain attribute filled in with the domain's NETBIOS name if found in the LDAP. If this NETBIOS name cannot be found, the domain name will be used instead.

> [!NOTE]
> If a NETBIOS name can be found, it will also replace the domain name in Cube user names.

### DMS Protocols

#### Configuring the layout of a matrix \[ID_25456\]\[ID_25892\]

A typical matrix layout shows the inputs on the left and the outputs at the top. However, in certain circumstances, it can be useful to visualize a matrix in an alternative way.

In a protocol.xml file, it is now possible to configure the following matrix layouts:

- InputLeftOutputTop (default)
- InputTopOutputLeft

See the following example:

```xml
<Type link="labels.xml" options="matrix=64,64,0,1,0,64,pages">matrix</Type>
<Discreets matrixLayout="InputTopOutputLeft">
```

Per matrix, the layout can then be overridden using the NotifyDataMiner call NT_UPDATE_PORTS. See the examples below:

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputLeftOutputTop");
```

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputTopOutputLeft");
```

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]",MatrixLayoutOptions.INPUT_LEFT_OUTPUT_TOP);
```

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]",MatrixLayoutOptions.INPUT_TOP_OUTPUT_LEFT);
```

> [!NOTE]
> To change the layout of a matrix in DataMiner Cube, right-click the matrix and select the layout in the *Edit* window.
>
> Note that, in the alarm template, the default layout (e.g. inputs on the left, outputs at the top) will always be used. Although the layout of a matrix can be defined per element, an alarm template is not linked to a single element.

#### Protocols: Compression algorithm(s) can now be specified in an Accept-Encoding header \[ID_25969\]

In a protocol, it is now possible to specify which compression algorithm(s) should be used when performing a HTTP GET request. See the following examples.

##### Example 1: Using compression algorithm 'deflate'

```xml
<Session id="2">
  <Connection id="1">
    <Request verb="PUT" url="/index.php">
      <Headers>
        <Header key="PutHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 2: Using compression algorithm 'gzip'

```xml
<Session id="4">
  <Connection id="1">
    <Request verb="POST" url="/index.php">
      <Headers>
        <Header key="Accept-Encoding">gzip</Header>
        <Header key="PostHeader">HEADER_DATA</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 3: Using compression algorithms 'deflate' and 'gzip"

```xml
<Session id="6">
  <Connection id="1">
    <Request verb="TRACE" url="/index.php">
      <Headers>
        <Header key="TraceHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate;q=0.5,gzip;q=1.0</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

> [!NOTE]
> When no \<Header key="Accept-Encoding"> tag was specified, gzip and deflate compression will be used by default.

### DMS Cube

#### Analytics tables in Elasticsearch database can now be included or excluded in custom DataMiner backup \[ID_25572\]

When you configure a custom backup in Cube, you can now select whether the Analytics tables in the Elasticsearch database, which are used for pattern matching, should be included. To do so, in System Center, go to the *content* tab of the *Backup* page, select the *Use custom backup* option, select *Create a backup of the database*, and either select or clear the selection of the checkbox *Include analytics tables in backup*. By default, this option is selected.

#### View cards: New columns added to view card list view \[ID_25715\]

On view cards, the list view now has two additional columns:

- *Element timeout time*: The total timeout time for each of the element’s connections (in milliseconds). This is the timeout time that corresponds with the element setting *The element goes into timeout state when \[...\]*. For multiple connections, the values are separated by commas.

- *Host ID*: The ID of the DMA hosting the element, service, SLA or redundancy group.

#### SNMP Managers: New alarm storm prevention option 'Group alarms with the same parameter name' \[ID_25717\]\[ID_25984\]

When you have enabled alarm storm prevention while configuring an SNMP manager, you can now choose to select the “Group alarms with the same parameter name” option.

If this option is selected, alarm storm prevention will happen based on the number of alarms occurring per parameter; otherwise, it will happen based on the number of alarms across parameters.

By default, this option is selected.

#### Services app: New 'Profiles' tab page \[ID_26111\]

The Services app now has a new “Profiles” tab page, which will allow you to manage Service Profile Definitions and Service Profile Instances.

### DMS Reports & Dashboards

#### Dashboards app: Component themes \[ID_25634\]

Within a particular dashboard theme, you can now define specific themes per component.

In a component theme, you can currently configure the following properties:

- Component title text styles
- Component background and font color
- Component margin and padding
- Component border styles
- Component shadows

You can change a component’s theme in the following ways:

- Select one of the existing component themes defined in the current dashboard theme.
- Customize the component’s current theme.

You can create new component themes in the following ways:

- Define a new component theme when creating or editing a dashboard theme.
- Save a component’s theme after having customized it.

> [!NOTE]
>
> - By default, a component will use the read-only default theme from the dashboard on which it is placed.
> - For backwards compatibility, components that previously inherited their styles from the dashboard theme will now use the default component theme instead.

#### Dashboards app: Embedding a single component into Visual Overview or a web page \[ID_25804\]

It is now possible to embed an individual Dashboards app component into Visual Overview or a web page.

Do the following:

1. In the Dashboards app, open the dashboard that contains the component you want to embed.

1. Right-click the component and select *Copy embed URL*.

1. Use the URL of the component in either a Visio page (e.g. in a shape with a data field of type “Link”) or a web page (e.g. in an \<img> tag).

A component URL has the following syntax:

```txt
http://<DMA>/embed?component=<SERIALIZED-COMPONENT>
```

> [!NOTE]
>
> - “SERIALIZED-COMPONENT” is a serialized representation of the component in JSON format.
> - If the component contains data, that data will automatically be included into the URL.

### DMS Automation

#### Possibility to add Attachments to tickets \[ID_25612\]

In a C# block of an Automation script, you can now add attachments to tickets.

In the TicketingHelper class and TicketingGatewayHelper, the “AttachmentsHelper Attachments” property will allow to manage ticket attachments using the following methods:

| Method                                                      | Function                                                                                     |
|-------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Add(TicketID ticketID, string fileName, byte\[\] fileBytes) | Add an attachment to a ticket                                                                |
| List\<string> GetFileNames(TicketID ticketID)               | Retrieve the names of all the attachments added to the ticket with the specified ticket ID.  |
| Delete(TicketID ticketID, string attachmentName)            | Deletes the attachment with the specified name from the ticket with the specified ticket ID. |
| byte\[\] Get(TicketID ticketID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array.             |

> [!NOTE]
>
> - The maximum size of ticket attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating ticket attachments requires the same user permissions as normal ticket management operations: Read permission to view and download attachments and Edit permission to add and delete attachments.
> - If a ticket is deleted, all its attachments will physically be deleted from disk. They will not be recoverable.
> - All ticket attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.
> - The Documents API can also be used to manage ticket attachments. Instead of using the above-mentioned methods, you can also use AddDocumentMessage, DeleteDocumentMessage, GetBinaryFileMessage and GetDocumentMessage. If you do so, specify the directory as “TICKET_ATTACHMENTS\\{DataminerID}\_{TicketId}” and make sure the property ID of type DMAObjectRef contains the ticket ID.

#### Run-time flag 'NoCheckingSets' now allows the 'After executing a SET command' option to be changed while a script is being run \[ID_25847\]

When you launch an Automation script, you can choose to select the “After executing a SET command” option. If you do so, every time the script performs a parameter or property update, it will wait for a return value indicating whether or not the update was successful.

From now on, the “NoCheckingSets” run-time flag will allow this option to be changed while a script is being run.

### DMS Maps

#### Open Street Maps can now be accessed offline \[ID_25928\]

It is now possible to access Open Street Maps offline when, in the server configuration file, you set AppVersion to “1” and MapsProvider to “OSM”.

See the following example of a ServerConfig.xml file.

```xml
<MapsServerConfig>
  <VirtualHosts>
    <VirtualHost hostname="*">
      <AppVersion>1</AppVersion>
      <MapsProvider>OSM</MapsProvider>
      <TilesServer>
        <BaseLayers>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
        </BaseLayers>
      </TilesServer>
      <GoogleMaps key="..."/>
      <MapQuest key="..."/>
      <OWM key="..."/>
    </VirtualHost>
  </VirtualHosts>
</MapsServerConfig>
```

Custom base layers can be defined in TilesServer.BaseLayers.BaseLayer tags. Those have the following attributes:

| Attribute | Description                                                                                               |
|-----------|-----------------------------------------------------------------------------------------------------------|
| key       | Key used to refer to a base layer acting as default map (in the MapType tag of a map configuration file). |
| name      | The name of the base layer that will be displayed in the base map selection box.                          |
| url       | The URL of the layer tiles exposed by the offline maps server.                                            |

### DMS CPE Management

#### Discreet parameters now supported in EPM search chains \[ID_25862\]

When a filter in an EPM search chain refers to a column parameter of type discreet, the filter will be displayed as a drop-down box rather than a text box.

If the filter is used for multiple tables, it will be displayed as a drop-down box as soon as one of the columns represents a discreet parameter.

When multiple columns have different discreet values, all these values will be displayed as long as they have a unique value and display string.

> [!NOTE]
> Dynamic discreet parameters are currently not supported.

### DMS Mobile apps

#### Interactive Automation scripts: UI components now have a TooltipText property \[ID_25609\] \[ID_25978\]

UI components in interactive Automation scripts launched from a mobile app can now have a tool tip configured by means of the UIBlockDefinition class property “TooltipText”.

### DMS Service & Resource Management

#### Profile data can now also be stored in Indexing Engine \[ID_25515\]\[ID_25758\]\[ID_26081\]

From now on, the following profile data can be stored either in XML format on the DataMiner Agents (default) or in Indexing Engine:

- ProfileDefinitions
- ProfileInstances
- ProfileParameters

#### New notice will now appear when a DMA that is not using Indexing Engine has an IDP license but no ServiceManager license \[ID_25762\]

The following notice will now appear when a DataMiner Agent that is not using Indexing Engine has an IDP license but no ServiceManager license:

```txt
DataMiner IDP is licensed, but no Elasticsearch database is active on the system. Therefore, scheduled workflows are not available.
```

This same notice will also be added to the ResourceManager log file.

#### GetEligibleResources: New ResourceFilter and RequiredCapabilitiesOrFiltered arguments \[ID_25786\]

The GetEligibleResources call has been extended with two new arguments:

| Argument | Description |
|--|--|
| ResourceFilter | New (optional) argument to filter the eligible resources. Resources that do not match the specified filter will not be returned as eligible resource. |
| RequiredCapabilitiesOrFiltered | Apart from the RequiredCapabilities argument, which can be used to specify an “AND” list of capabilities, this new (optional) RequiredCapabilitiesOrFiltered argument can be used to specify an “OR” list of capabilities. |

> [!NOTE]
> The following new API call has been added to the ResourceManager-Helper:
>
> - public EligibleResourceResult GetEligibleResources(EligibleResourceContext context)
>
> This new call allows you to combine all existing and new parameters of the GetEligibleResources calls. The legacy GetEligibleResources and GetEligibleResourceForServiceNodeWithUsageInfo calls will now link to this new call.

### DMS Spectrum Analysis

#### DataMiner Cube - Spectrum Analysis: A preset will now also include the decimals to be used when displaying DBm values in spectrum graphs \[ID_25871\]

When you save a spectrum preset, from now on, that preset will also include the amount of decimals to be used when displaying DBm values on the Y axis of a spectrum graph.

## Changes

### Enhancements

#### DataMiner Installer now targets Microsoft .NET Framework 4.6.2 \[ID_25378\]

The DataMiner Installer now targets Microsoft .NET Framework 4.6.2.

#### SLLogCollector: Options selected by default when you launch the tool \[ID_25631\]

From now on, when you launch the SLLogCollector tool, the following options will be selected by default:

- Include memory dump (when run-time errors have been found on the system)
- Save to SLLogCollector folder on desktop

#### Logs will now include Cassandra yaml file parsing errors \[ID_25809\]

From now on, Cassandra yaml file parsing errors will also be logged.

#### BPA test framework update \[ID_25840\]\[ID_25891\]

A number of enhancements have been made to the BPA test framework.

Also, special user permissions will now be required to create, update, delete, read, and execute BPA tests and to be able to receive BPA test results.

Best Practice Analysis (BPA) tests can be uploaded and run using the SLNetClientTest tool.

#### Enhanced service elements will now be started along with all other elements \[ID_25843\]

Up to now, enhanced service elements would be started when the services were loaded. Now, they will be started along with all other elements.

#### Cassandra 3.7 installer now uses AdoptOpenJDK 8u252 \[ID_25850\]

The Cassandra 3.7 installer now uses AdoptOpenJDK 8u252.

#### Service & Resource Management: Deleting resources based only on ID \[ID_25867\]

When a DataMiner Agent was asked to delete a resource, up to now, it would only delete that resource when all resource properties received matched the resource to be deleted. From now on, a DataMiner Agent will delete a resource based solely on the resource ID received in the delete request.

#### SLDMS: Object handling enhancements to prevent memory leaks \[ID_25879\]

In SLDMS, a number of object handling enhancements have been made to prevent memory leaks.

#### Alarm queuing enhancements to prevent alarms from getting stuck in the Alarm Console \[ID_25927\]

In some rare cases, alarms could get stuck in the Alarm Console. This has now been prevented by enhancing the alarm queuing mechanism.

#### EULA page updated \[ID_25937\]

The EULA page has been updated.

This page can be accessed by clicking *Skyline software license terms* in the *About* window of Cube and the HTML5 applications, or by going to `http://<IP address of DMA>/EULA.htm` on the DataMiner Agent.

#### DataMiner Cube - Protocols & Templates: Link to Cube logging added to error window that appears when a server-side error occurred while uploading a functions file \[ID_25953\]

When a server-side error occurs while uploading a functions file in the Protocols & Templates app, from now on, a hyperlink in the error window will allow you to check the cause of the error in the Cube logging.

#### DataMiner Cube - Ticketing: Tickets page will now by default list all tickets associated with the first ticket domain that is found \[ID_25963\]

When, in a card, you selected the TICKETS page, up to now, that page would show a list of all open tickets across all known ticket domains. From now on, the list of open tickets will by default be restricted to the tickets associated with the first ticket domain that is found.

#### Service & Resource Management: Enhancements with regard to quarantine-related messaging \[ID_25966\]

A number of enhancements have been made to the messages that appear when managing profile instances, especially with regard to quarantining.

#### Enhanced performance of Visio shapes linked to an EPM object but not to a view \[ID_25972\]

Due to a number of enhancements, overall performance of Visio shapes linked to EPM objects has increased, especially when they are not linked to a view.

#### Error message 'Unknown destination DataMiner specified' replaced by 'Unable to find hosting agent. The agent might still be starting up' \[ID_25976\]

Up to now, when the hosting agent of an element or service could not be found, an “Unknown destination DataMiner specified” error would be thrown. This error message has now been replaced by “Unable to find hosting agent. The agent might still be starting up”.

#### DataMiner Cube - Router Control: Highlighting now also supported when working with linked pages \[ID_26001\]

When you select a routed output in the Router Control app, the crosspoints. the IO button and the tab item(s) of the corresponding button will all be highlighted.

Now, this highlighting feature is also supported in a dynamic environment, i.e. when working with linked pages.

#### DataMiner Cube - Trending: Viewing and creating tags only possible if both Cassandra and Indexing Engine are installed \[ID_26010\]

From now on, viewing and creating recurring patterns in trend data (i.e. “tags”) will only be possible on systems that have both Cassandra and Indexing Engine installed.

#### DataMiner.xml: XML namespace now set during DataMiner installation \[ID_26011\]

In the *DataMiner.xml* file, from now on, the XML namespace will by default be set to `xmlns=http://www.skyline.be/config/dataminer` during a DataMiner installation.

### Fixes

#### Indexing Engine: Active alias would incorrectly be created as index \[ID_25461\]

In some rare cases, the active alias would be created as index.

#### Problem with SLNet connections when a large amount of requests were sent over them \[ID_25613\]

In some cases, an SLNet connection could break when a large amount of requests were sent over it.

Together with this fix, the following changes have also been made:

- Automatic recovery of SLNet connections has now been rendered obsolete and is no longer supported.

- The event cache log options (SLNetClientTest \> Advanced \> Options \> SLNet Options \> EventCacheLogOptions) now support “filter=xxxxx” keywords to limit the output to specific types. “xxxxx” can be “element”, “dma”, “alarm” or any of the types listed in SLNetClientTest \> Diagnostics \> Caches & Subscriptions \> GeneralCacheStats \> Cache for xxxxxxxxx.

#### Miscellaneous small fixes \[ID_25645\]

A number of small fixes have been made, including the following:

- In some cases, a run-time error could occur in “Database Offload Thread \[local\]” when a DataMiner startup took too long.

- SLElement could leak memory when registering a link with an empty filter or when initializing a parameter group.

- The SLElement.txt log file will now indicate that it is loading all active alarms from the database. This will make it easier to analyze DataMiner startup issues.

- The license check will now skip adapters without MAC address.

- In some cases, especially when dealing with SNMPv3 elements, the following error could appear.

    ```txt
    Failed trying to send an initial cached event to EGMCC [...] System.ArgumentNullException: Value cannot be null
    ```

- In some cases, the following error could be added to the SLErrors.txt log file.

    ```txt
    SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|1|Failed to deserialize TableDefinitions Could not find file 'C:\Skyline DataMiner\Database\TableDefinitionCollection.xml'
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup for each exported protocol:

    ```txt
    CDataMiner::NotifySLElementProcess|ERR|-1|Notify SLElement process failed (86): 0x8004024c: The element is unknown.
    CExportProtocolsHandler::ExportProtocols|ERR|0|Failed exporting protocol with 0x8004024c The element is unknown.
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup:

    ```txt
    Could not load XSD: C:\Skyline DataMiner\Tools\Schemas\MobileGatewaySchema.xsd
    XSD URI was empty for: C:\Skyline DataMiner\Elements\xxxxxxxxx\Description.xml
    ```

#### DataMiner Cube - Visual Overview: Problem with session variables used by the Resource Manager timeline component \[ID_25718\]

In some cases, certain session variables used by the Resource Manager timeline component (e.g. YAxisResources) would not work properly when the page contained a setvar shape but no initvar action.

#### Ticketing app: Certain selection boxes were not scrollable \[ID_25719\]

Certain selection boxes, like the ticket domain selector in the subheader, would incorrectly not be scrollable.

#### DataMiner Cube: Properties window of service or view would show incorrect Visio file extension \[ID_25760\]

In the Properties window of a service or a view, you can check the name of the Visio file that was assigned to that service or view. In some cases, when the extension of the file was “vdx” or “zip”, it would incorrectly be shown as “vsdx”.

#### Element that generated a large amount of data would be missing data after being restarted \[ID_25761\]

When an element that generates a large amount of data was restarted, in some cases, it would be missing data when it started up again.

#### Upgrade action 'CassandraActiveAlarmsRootOnlyUpgrade' would incorrectly only be run once \[ID_25764\]

Up to now, when a DataMiner Agent with a Cassandra database was upgraded, the upgrade action “CassandraActiveAlarmsRootOnly” would incorrectly only be run once. Now, it will be rerun at every upgrade until no more errors are reported.

Also, an additional upgrade action will now be run at every upgrade. The “CassandraDistinct-PropertiesUpgrade” action will check all alarms in the database and fix any incorrect alarm properties it encounters.

#### DataMiner Cube - Visual Overview: Problem with parameter chart updates \[ID_25777\]

When using a parameter chart, in some rare cases, that chart’s update interval would incorrectly be set to 0 seconds. As a result, it would be updated constantly. From now on, setting the update interval of a parameter chart to 0 seconds will no longer be possible.

#### DataMiner Cube - Profiles app: Modification of profile instance field 'applies to' would incorrectly be disregarded \[ID_25790\]

When configuring a profile instance in the Profiles module, you can indicate to which profile definition the instance applies. In some cases, when you changed this field, the modification would be disregarded.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25794\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### Automation: Email action that used an aggregation rule would be saved incorrectly \[ID_25800\]

When, in an Automation script, you added an email action that sent an PDF report and used an aggregation rule, in some cases, the action’s aggregation rule information would not be saved correctly.

#### Service & Resource Management: Problem when updating multiple ReservationInstance properties in rapid succession \[ID_25808\]

When multiple ReservationInstance properties were updated in rapid succession, in some cases, “PropertiesWereAlreadyModified” errors could be thrown.

#### DataMiner Cube - Alarm Console: Problem when enabling or disabling history tracking \[ID_25813\]

When you enabled or disabled history tracking while viewing an alarm tab page that contained a large number of alarms, in some cases, Cube would become unresponsive.

#### DataMiner Cube - Visual Overview: Problem with \[profile:xxx\] placeholder \[ID_25817\]

In some cases, the \[profile:xxx\] placeholder would no longer be resolved correctly.

#### DataMiner Cube - Router Control: Options field of InfoPanel block would incorrectly be disregarded \[ID_25818\]

When, while configuring an InfoPanel block in the Router Control app, options had been specified in the Options field, those options would incorrectly be disregarded when the matrix configuration was loaded.

#### DataMiner Cube - Resources app: Incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined \[ID_25835\]

When adding or editing a resource in the Resources app, in some cases, an incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined.

#### Indexing Engine: Memory issues caused by custom data paging cooking not being cleaned up \[ID_25836\]

On systems running Indexing Engine, custom data paging cookies would no longer be cleaned up. In some cases, this could lead to memory issues.

#### Memory leak in SLPort \[ID_25846\]

While a SmartIPHeader UDP socket was receiving data from multiple clients, in some cases, the SLPort process could leak memory when another client was detected.

#### Unnecessary 'codedom' tag in SLNet.exe.config file \[ID_25868\]

In some cases, the SLNet.exe.config file would contain an unnecessary “codedom” tag. On certain DataMiner Agents, this could lead to issues when generating functions.

#### Disabling the 'Enable DVE child creation' option in the 'Advanced element settings' would prevent the creation of virtual functions \[ID_25869\]

In some cases, disabling the Enable DVE child creation option in the Advanced element settings would incorrectly prevent the creation of virtual functions.

#### Alarms would have incorrect properties \[ID_25880\]

In some cases, alarms would have incorrect properties.

#### EPM view cards would not always have the same title \[ID_25895\]

If the name of the enhanced view was not identical to the system name, the EPM card of that view would not always have the same title. The title displayed would depend on the way in which the card was opened.

#### DataMiner Cube - Visual Overview: Filtered alarm tab would not open when you clicked an alarm summary shape \[ID_25901\]

When you click a shape with an alarm filter in an *AlarmSummary* data item and the name of an alarm tab in an *AlarmTab* data item, Cube will open the specified alarm tab (if it has a filter applied) and apply the alarm filter specified in the *AlarmSummary* data item.

In some cases, when the tab page did not exist yet and the Alarm Console was collapsed, the tab page was created but the Alarm Console would incorrectly not be opened.

#### Interactive Automation scripts: Some drop-down boxes would unnecessarily trigger a refresh of the UI \[ID_25902\]

In some cases, drop-down boxes would unnecessarily trigger a refresh of the UI.

#### Problem caused by missing \<BackupSettings> tag in MaintenanceSettings.xml \[ID_25908\]

Up to now, when the \<BackupSettings> tag was missing from the MaintenanceSettings.xml file, it would not be possible to save backup settings.

From now on, when the MaintenanceSettings.xml file does not contain a \<BackupSettings> tag, it will automatically be added and filled with the correct settings.

#### DataMiner Cube: Element card of a Dynamic Virtual Element incorrectly had a 'Notes' page \[ID_25910\]

Up to now, when you opened the card of a Dynamic Virtual Element, it incorrectly had a Notes page. As DVE elements currently cannot have notes, this page has been removed.

#### Dashboards app - Service Definition component: Booking ID not passed to the script when clicking a node \[ID_25912\]

When, in a service definition component linked to a booking, you clicked a node that launched an Automation script, in some cases, the booking ID would not be passed to the script.

#### DataMiner Cube - Listview: Problem when column icons got a severity update \[ID_25916\]

When a column in a ListView component was configured to show alarm icons, in some cases, an error could occur when one of those icons got a severity update.

#### Duplicate logger table storage types would incorrectly be created when migrating from MySQL to Cassandra \[ID_25935\]

When migrating a database from MySQL to Cassandra, in some cases, duplicate logger table storage types would incorrectly be created.

#### Problems when generating a PDF report based on a dashboard from the new app \[ID_25939\]

In PDF reports generated based on dashboards from the new Dashboards app, the page numbers would be incorrect and the service state visualizations would not be displayed correctly.

#### Problem when migrating newly created trend data from MySQL to Cassandra \[ID_25971\]

When you created an element or started trending a parameter and then, afterwards, migrated from MySQL to Cassandra, in some cases, the newly created trend data would not be migrated.

#### Automation: Problem when calling FindElements with a 'WarningOnly' element filter \[ID_25973\]

When the FindElements method was called with a “WarningOnly” element filter, in some cases, it would incorrectly return all elements.

#### Problem when multiple smart-serial elements using the same port restarted \[ID_25982\]

In some rare cases, an error could occur when multiple smart-serial elements using the same port restarted.

#### DataMiner Cube - Visual Overview: Tree view with 'SingleSelectionMode' option would incorrectly allow multiple values to be selected after a filter had been applied \[ID_25986\]

When, on a Visio page, you selected an item in a tree view to which you had added the “SingleSelectionMode” option, applied a filter and then selected another item, in some cases, the item you selected previously would incorrectly remain selected.

#### Problem when a table filter contained the table parameter ID instead of the column parameter ID \[ID_25988\]

When a DynamicTableQuery is passed to SLelement, it is possible to add a column filter in one of the following formats:

- Value= \<COLUMNPID> == \<Value>
- Fullfilter= \<COLUMNPID>==\<Value>

Up to now, when such a column filter contained the table parameter ID instead of the column parameter ID, in some cases, either a NULL response would incorrectly be returned or an error would occur in SLElement.

#### SLAnalytics: Different agents in a DMS would incorrectly each create a different configuration file \[ID_26005\]

Due to a synchronization issue, in some rare cases, different agents in a DMS would incorrectly each create a different SLAnalytics configuration file.

#### Restarting an element immediately after masking it would cause it to be shown as unmasked for a short period of time \[ID_26070\]

When you masked an element and then immediately restarted it, in some rare cases, it could be shown as unmasked for a short period of time.

#### Incorrect page margins in PDF reports sent by an Automation script \[ID_26090\]

When an Automation script sent a PDF report based on a dashboard, in some cases, the page margins in that PDF report would be incorrect.

#### DataMiner Cube - Trending: Trend graph of aggregation parameter did not show any data \[ID_26172\]

When you opened the trend graph of an aggregation parameter, in some cases, no trend data was shown.

#### Visual Overview: Tabs names not displayed when alternative tab control style was used \[ID_26181\]

When a tab control in a Visio drawing was configured to use an alternative style with the option "*TabControlStyle=2*", it could occur that tab names were not displayed.
